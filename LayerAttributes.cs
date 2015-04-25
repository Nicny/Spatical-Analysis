using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SystemUI;



namespace SpatialDataManagement
{
    public partial class AttributesContextMenu : Form
    {
        IFeatureLayer currentLayer = null;
        IMap m_map = null;
        IActiveView m_activeView = null;

        const string m_dataSetName = "m_layerDataSet";
        const string m_dataSourceName = "GeoDataSource";
        DataSet m_layerDataSet = new DataSet(m_dataSetName);
        int currentRow = 0;//鼠标点击位置所在的行
        int x, y;  //鼠标点击的位置
        string strOBJECTID = null;
        public AttributesContextMenu(IMap map, IFeatureLayer featureLayer)
        {
            InitializeComponent();
            m_map = map;
            m_activeView = map as IActiveView;
            currentLayer = featureLayer;
        }

        private void AttributesContextMenu_Load(object sender, EventArgs e)
        {
            this.Text = currentLayer.Name + "  属性表";
            FindOIDField();
            if (strOBJECTID == null) return;
            int rowCount = ConstructDataSet(currentLayer);
            dataGridView1.DataSource = m_layerDataSet;
            dataGridView1.DataMember = currentLayer.Name;
            toolStripStatusLabel1.Text = "选择记录数：0";
            toolStripStatusLabel2.Text = "总记录数：" + currentLayer.FeatureClass.FeatureCount(null).ToString();
        }

        private void FindOIDField()
        {
            if (currentLayer == null) return;
            IFields fields = currentLayer.FeatureClass.Fields;
            IField field;
            for (int i = 0; i < fields.FieldCount; i++)
            {
                field = fields.get_Field(i);
                if (field.Type == esriFieldType.esriFieldTypeOID)
                {
                    strOBJECTID = field.Name;
                    break;
                }
            }
        }

        private void OnActiveViewEventsAfterDraw(IDisplay Display, esriViewDrawPhase phase)
        {
            if (m_activeView == null) return;
            if (phase != esriViewDrawPhase.esriViewGeoSelection) return;

            ISelectionSet selectedFeatures = GetSelectedFeature();
            UpdateDataGridView(selectedFeatures);

        }
        private void OnFeatureLayerSelectionChanged()
        {
            ISelectionSet selectedFeatures = GetSelectedFeature();
            UpdateDataGridView(selectedFeatures);
        }

        private void UpdateDataGridView(ISelectionSet selectedFeatures)
        {
            //if (selectedFeatures.Count == 0 && dataGridView1.SelectedRows.Count != 0)
            //    dataGridView1.ClearSelection();

            IEnumIDs enumIDs = selectedFeatures.IDs;
            int iD = enumIDs.Next();
            while (iD != -1) //-1 is reutned after the last valid ID has been reached        
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == iD.ToString())
                        dataGridView1.Rows[i].Selected = true;
                }

                iD = enumIDs.Next();
            }
        }

        private ISelectionSet GetSelectedFeature()
        {
            if (currentLayer == null) return null;

            IFeatureSelection featureSelection = currentLayer as IFeatureSelection;
            ISelectionSet selectionSet = featureSelection.SelectionSet;

            return selectionSet;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            m_map.ClearSelection();
            m_activeView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, m_activeView.Extent);

            DataGridViewSelectedRowCollection selectedRows = dataGridView1.SelectedRows;
            if (selectedRows == null) return;

            string strOID = string.Empty;
            List<string> OIDList = new List<string>();

            for (int i = 0; i < selectedRows.Count; i++)
            {
                DataGridViewRow row = selectedRows[i];
                strOID = row.Cells[strOBJECTID].Value.ToString();
                //strOID = row.Cells[0].Value.ToString();
                OIDList.Add(strOID);
            }
            SelectFeatures(OIDList);
            toolStripStatusLabel1.Text = "选择记录数：" + OIDList.Count.ToString();
            toolStripStatusLabel2.Text = "总记录数：" + currentLayer.FeatureClass.FeatureCount(null).ToString();
        }
       
        private void SelectFeatures(List<string> oidList)
        {
            IFeatureClass featureClass = currentLayer.FeatureClass;
            string strID = string.Empty;
            string[] IDs = oidList.ToArray();
            for (int i = 0; i < IDs.Length; i++)
            {
                strID = IDs[i];
                IFeature selectedFeature = featureClass.GetFeature(Convert.ToInt32(strID));
                m_map.SelectFeature(currentLayer, selectedFeature);
            }
            m_activeView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, m_activeView.Extent);
        }


        #region "ConstructDataSet"
        private int ConstructDataSet(IFeatureLayer pFeatLyr)
        {
            ILayerFields pFeatlyrFields = pFeatLyr as ILayerFields;
            IFeatureClass pFeatCls = pFeatLyr.FeatureClass;
            int rows = 0;
            if (m_layerDataSet.Tables[pFeatLyr.Name] == null)
            {
                DataTable pTable = new DataTable(pFeatLyr.Name);
                DataColumn pTableCol;
                for (int i = 0; i <= pFeatlyrFields.FieldCount - 1; i++)
                {
                    pTableCol = new DataColumn(pFeatlyrFields.get_Field(i).AliasName);
                    pTable.Columns.Add(pTableCol);
                    pTableCol = null;
                }

                IFeatureCursor features = pFeatLyr.Search(null, false);
                IFeature feature = features.NextFeature();
                while (feature != null)
                {
                    DataRow pTableRow = pTable.NewRow();
                    for (int i = 0; i <= pFeatlyrFields.FieldCount - 1; i++)
                    {
                        //pTableRow[i] = feature.get_Value(i);
                        if (pFeatlyrFields.FindField(pFeatCls.ShapeFieldName) == i)
                        {
                            pTableRow[i] = pFeatCls.ShapeType;
                        }
                        else
                        {
                            pTableRow[i] = feature.get_Value(i);
                        }
                    }
                    pTable.Rows.Add(pTableRow);
                    feature = features.NextFeature();
                }
                rows = pTable.Rows.Count;
                m_layerDataSet.Tables.Add(pTable);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(features);

            }
            return rows;
        }

        #endregion

        private void 闪烁该要素ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanToFlash();
        }

        private void 缩放到该要素ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                IEnvelope pEnvelope = new EnvelopeClass();
                IFeature selectedFeature = GetCurrentFeature();
                m_map.SelectFeature(currentLayer, selectedFeature);
                if (currentLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
                {
                    pEnvelope = m_activeView.Extent;
                    pEnvelope.Height = pEnvelope.Height / 2;
                    pEnvelope.Width = pEnvelope.Width / 2;
                    pEnvelope.CenterAt(selectedFeature.ShapeCopy as IPoint);
                }
                else
                {
                    pEnvelope = selectedFeature.Extent;
                }
                m_activeView.Extent = pEnvelope;
                m_activeView.PartialRefresh((esriViewDrawPhase)6, null, m_activeView.Extent);
            }
            catch (Exception)
            {
                return;
            }
        }


        private void 平移到该要素ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanToFlash();
        }

        private void 缩放到当前图层ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_activeView.Extent = ((IGeoDataset)currentLayer).Extent;
            m_activeView.ScreenDisplay.UpdateWindow();
            m_activeView.PartialRefresh((esriViewDrawPhase)6, null, m_activeView.Extent);
        }

        private void 缩放到所有选择要素ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IEnvelope wholeEnvelope = GetLayerSelectedFeaturesEnvelope(currentLayer);
            if (wholeEnvelope == null) return;

            m_activeView.Extent = wholeEnvelope;
            //m_activeView.ScreenDisplay.UpdateWindow();
            m_activeView.PartialRefresh((esriViewDrawPhase)6, null, m_activeView.Extent);
        }

        private void 清楚所有选择要素ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_map.ClearSelection();
            m_activeView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, m_activeView.Extent);
            dataGridView1.ClearSelection();
        }

        private void 删除所有选择要素ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelectedFeatures();
        }
        private IFeature GetCurrentFeature()
        {
            try
            {
                string strID = dataGridView1.Rows[currentRow].Cells[strOBJECTID].Value.ToString();
                //string strID = dataGridView1.Rows[currentRow].Cells[0].Value.ToString();

                IFeatureClass featureClass = currentLayer.FeatureClass;
                IFeature selectedFeature = featureClass.GetFeature(Convert.ToInt32(strID));
                return selectedFeature;
            }
            catch (Exception)
            {
                return null;
            }
        }
        private void PanToFlash()
        {
            try
            {
                IFeature selectedFeature = GetCurrentFeature();
                IGeometry geometry = selectedFeature.Shape;
                IPoint pCenterPoint = new PointClass();
                double x = (geometry.Envelope.LowerLeft.X + geometry.Envelope.UpperRight.X) / 2;
                double y = (geometry.Envelope.LowerLeft.Y + geometry.Envelope.UpperRight.Y) / 2;
                pCenterPoint.PutCoords(x, y);

                IDisplayTransformation pDisplayTransform = m_activeView.ScreenDisplay.DisplayTransformation;
                IEnvelope pEnvelope = pDisplayTransform.VisibleBounds;
                pEnvelope.CenterAt(pCenterPoint);
                pDisplayTransform.VisibleBounds = pEnvelope;

                //m_map.SelectFeature(currentLayer, selectedFeature);

                m_activeView.PartialRefresh((esriViewDrawPhase)6, null, m_activeView.Extent);
                m_activeView.ScreenDisplay.UpdateWindow();

                ISymbol symbol = CreateSimpleSsymbol(geometry.GeometryType);
                if (symbol == null) return;
                DrawSymbol(symbol, geometry);
            }
            catch (Exception)
            {
                return;
            }
        }

        private ISymbol CreateSimpleSsymbol(esriGeometryType geometryType)
        {
            ISymbol symbol = null;
            switch (geometryType)
            {
                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPoint:
                    ISimpleMarkerSymbol markerSymbol = new SimpleMarkerSymbolClass();
                    markerSymbol.Color = getRGB(255, 0, 0);
                    markerSymbol.Size = 8;
                    symbol = markerSymbol as ISymbol;
                    break;
                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolyline:
                    ISimpleLineSymbol lineSymbol = new SimpleLineSymbolClass();
                    lineSymbol.Color = getRGB(255, 0, 0);
                    lineSymbol.Width = 4;
                    symbol = lineSymbol as ISymbol;
                    break;
                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon:
                    ISimpleFillSymbol fillSymbol = new SimpleFillSymbolClass();
                    fillSymbol.Color = getRGB(255, 0, 0);
                    symbol = fillSymbol as ISymbol;
                    break;
                default:
                    break;
            }
            symbol.ROP2 = esriRasterOpCode.esriROPNotXOrPen;

            return symbol;
        }

        private IColor getRGB(int yourRed, int yourGreen, int yourBlue)
        {

            IRgbColor pRGB;
            pRGB = new RgbColorClass();
            pRGB.Red = yourRed;
            pRGB.Green = yourGreen;
            pRGB.Blue = yourBlue;
            pRGB.UseWindowsDithering = true;
            return pRGB;
        }


        private void DrawSymbol(ISymbol symbol, IGeometry geometry)
        {
            IScreenDisplay pDisplay = m_activeView.ScreenDisplay;

            pDisplay.StartDrawing(0, (short)esriScreenCache.esriNoScreenCache);
            pDisplay.SetSymbol(symbol);
            for (int i = 0; i < 10; i++)
            {
                switch (geometry.GeometryType)
                {
                    case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPoint:
                        pDisplay.DrawPoint(geometry);
                        break;
                    case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryMultipoint:
                        pDisplay.DrawMultipoint(geometry);
                        break;
                    case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolyline:
                        pDisplay.DrawPolyline(geometry);
                        break;
                    case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon:
                        pDisplay.DrawPolygon(geometry);
                        break;
                    default:
                        break;
                }
                System.Threading.Thread.Sleep(100);
            }
            //m_mapControl.FlashShape(geometry, 5, 300, symbol);
            pDisplay.FinishDrawing();
        }
        private IEnvelope GetSelectedFeaturesExtent()
        {
            IEnvelope mapEnvelope = new EnvelopeClass();
            UID uid = new UIDClass();
            uid.Value = "{E156D7E5-22AF-11D3-9F99-00C04F6BC78E}";
            //{6CA416B1-E160-11D2-9F4E-00C04F6BC78E} IDataLayer
            //{40A9E885-5533-11d0-98BE-00805F7CED21} IFeatureLayer
            //{E156D7E5-22AF-11D3-9F99-00C04F6BC78E} IGeoFeatureLayer
            //{34B2EF81-F4AC-11D1-A245-080009B6F22B} IGraphicsLayer
            //{5CEAE408-4C0A-437F-9DB3-054D83919850} IFDOGraphicsLayer
            //{0C22A4C7-DAFD-11D2-9F46-00C04F6BC78E} ICoverageAnnotationLayer
            //{EDAD6644-1810-11D1-86AE-0000F8751720} IGroupLayer
            IEnumLayer layers = m_map.get_Layers(uid, false);
            layers.Reset();
            IGeoFeatureLayer geoFeatureLayer = layers.Next() as IGeoFeatureLayer;
            int i = 1;
            while (geoFeatureLayer != null)
            {
                IEnvelope layerEnvelope = GetLayerSelectedFeaturesEnvelope(geoFeatureLayer);
                if (layerEnvelope == null) goto gotoLabel;
                if (i == 1)
                    mapEnvelope = layerEnvelope;
                else
                {
                    mapEnvelope.Union(layerEnvelope);
                }
                i++;
            gotoLabel: geoFeatureLayer = layers.Next() as IGeoFeatureLayer;
            }
            return mapEnvelope;
        }
        private IEnvelope GetLayerSelectedFeaturesEnvelope(IFeatureLayer pFeatLyr)
        {
            IEnvelope layerEnvelope = null;
            IFeatureClass pFeatCls = pFeatLyr.FeatureClass;
            IFeatureSelection selectLayer = pFeatLyr as IFeatureSelection;
            ISelectionSet selectionSet = selectLayer.SelectionSet;
            IEnumIDs enumIDs = selectionSet.IDs;
            IFeature feature;
            int i = 1;
            int iD = enumIDs.Next();
            while (iD != -1) //-1 is reutned after the last valid ID has been reached        
            {
                feature = pFeatCls.GetFeature(iD);
                IEnvelope envelope = feature.ShapeCopy.Envelope;
                if (i == 1)
                    layerEnvelope = envelope;
                else
                {
                    layerEnvelope.Union(envelope);
                }
                i++;
                iD = enumIDs.Next();
            }
            return layerEnvelope;
        }

        private void DeleteSelectedFeatures()
        {
            IFeatureClass pFeatCls = currentLayer.FeatureClass;
            IFeatureSelection selectLayer = currentLayer as IFeatureSelection;
            ISelectionSet selectionSet = selectLayer.SelectionSet;
            IEnumIDs enumIDs = selectionSet.IDs;
            IFeature feature;
            int iD = enumIDs.Next();
            while (iD != -1) //-1 is reutned after the last valid ID has been reached        
            {
                feature = pFeatCls.GetFeature(iD);
                feature.Delete();
                iD = enumIDs.Next();
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                currentRow = e.RowIndex;
                x = e.X;
                y = e.Y;
            }
        }
    }
}
