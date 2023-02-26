namespace Baodongchem
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Timer_display = new System.Windows.Forms.Timer(this.components);
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.Timer_loaddata = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar10 = new DevExpress.XtraBars.Bar();
            this.st_PLCSI = new DevExpress.XtraBars.BarStaticItem();
            this.st_PLCSIPACK = new DevExpress.XtraBars.BarStaticItem();
            this.st_PLCLS = new DevExpress.XtraBars.BarStaticItem();
            this.st_PLCAB = new DevExpress.XtraBars.BarStaticItem();
            this.st_PLCOM = new DevExpress.XtraBars.BarStaticItem();
            this.st_THD = new DevExpress.XtraBars.BarStaticItem();
            this.bt_Setting = new DevExpress.XtraBars.BarButtonItem();
            this.bt_Calibration = new DevExpress.XtraBars.BarButtonItem();
            this.btGioithieu = new DevExpress.XtraBars.BarSubItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.bar5 = new DevExpress.XtraBars.Bar();
            this.bar6 = new DevExpress.XtraBars.Bar();
            this.bar8 = new DevExpress.XtraBars.Bar();
            this.bar9 = new DevExpress.XtraBars.Bar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.BT_RESET_AL = new System.Windows.Forms.Button();
            this.BT_TATCOI = new System.Windows.Forms.Button();
            this.bt_Report = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btPack = new System.Windows.Forms.Button();
            this.bt_MccRoom = new System.Windows.Forms.Button();
            this.bt_Rto = new System.Windows.Forms.Button();
            this.bt_FumeDust = new System.Windows.Forms.Button();
            this.bt_AirPressure = new System.Windows.Forms.Button();
            this.bt_VaccumPump = new System.Windows.Forms.Button();
            this.bt_Waterpump = new System.Windows.Forms.Button();
            this.timer_excel_real = new System.Windows.Forms.Timer(this.components);
            this.tabMain = new DevExpress.XtraTab.XtraTabControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.SuspendLayout();
            // 
            // Timer_display
            // 
            this.Timer_display.Enabled = true;
            this.Timer_display.Interval = 1000;
            this.Timer_display.Tick += new System.EventHandler(this.Timer_display_Tick);
            // 
            // Timer_loaddata
            // 
            this.Timer_loaddata.Enabled = true;
            this.Timer_loaddata.Interval = 1000;
            this.Timer_loaddata.Tick += new System.EventHandler(this.Timer_loaddata_Tick);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1364, 706);
            this.panel2.TabIndex = 0;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar10});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btGioithieu,
            this.st_PLCSI,
            this.st_PLCLS,
            this.st_PLCAB,
            this.bt_Setting,
            this.st_PLCOM,
            this.bt_Calibration,
            this.st_THD,
            this.st_PLCSIPACK});
            this.barManager1.MaxItemId = 21;
            this.barManager1.OptionsLayout.AllowAddNewItems = false;
            this.barManager1.OptionsLayout.ResetRecentItems = false;
            // 
            // bar10
            // 
            this.bar10.BarName = "Custom 3";
            this.bar10.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar10.DockCol = 0;
            this.bar10.DockRow = 0;
            this.bar10.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar10.FloatLocation = new System.Drawing.Point(28, 267);
            this.bar10.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.st_PLCSI),
            new DevExpress.XtraBars.LinkPersistInfo(this.st_PLCSIPACK),
            new DevExpress.XtraBars.LinkPersistInfo(this.st_PLCLS),
            new DevExpress.XtraBars.LinkPersistInfo(this.st_PLCAB),
            new DevExpress.XtraBars.LinkPersistInfo(this.st_PLCOM),
            new DevExpress.XtraBars.LinkPersistInfo(this.st_THD),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bt_Setting, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bt_Calibration, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btGioithieu, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar10.OptionsBar.AllowQuickCustomization = false;
            this.bar10.OptionsBar.AutoPopupMode = DevExpress.XtraBars.BarAutoPopupMode.None;
            this.bar10.OptionsBar.DrawBorder = false;
            this.bar10.OptionsBar.DrawDragBorder = false;
            this.bar10.Text = "Custom 3";
            // 
            // st_PLCSI
            // 
            this.st_PLCSI.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.st_PLCSI.Border = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.st_PLCSI.Caption = "PLC-Si";
            this.st_PLCSI.Id = 13;
            this.st_PLCSI.ImageOptions.Image = global::Baodongchem.Properties.Resources.PLC;
            this.st_PLCSI.ItemAppearance.Normal.BackColor = System.Drawing.Color.Red;
            this.st_PLCSI.ItemAppearance.Normal.ForeColor = System.Drawing.Color.White;
            this.st_PLCSI.ItemAppearance.Normal.Options.UseBackColor = true;
            this.st_PLCSI.ItemAppearance.Normal.Options.UseForeColor = true;
            this.st_PLCSI.Name = "st_PLCSI";
            this.st_PLCSI.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // st_PLCSIPACK
            // 
            this.st_PLCSIPACK.Border = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.st_PLCSIPACK.Caption = "PLC-SiPack";
            this.st_PLCSIPACK.Id = 20;
            this.st_PLCSIPACK.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("st_PLCSIPACK.ImageOptions.SvgImage")));
            this.st_PLCSIPACK.ItemAppearance.Normal.BackColor = System.Drawing.Color.Red;
            this.st_PLCSIPACK.ItemAppearance.Normal.ForeColor = System.Drawing.Color.White;
            this.st_PLCSIPACK.ItemAppearance.Normal.Options.UseBackColor = true;
            this.st_PLCSIPACK.ItemAppearance.Normal.Options.UseForeColor = true;
            this.st_PLCSIPACK.Name = "st_PLCSIPACK";
            this.st_PLCSIPACK.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // st_PLCLS
            // 
            this.st_PLCLS.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.st_PLCLS.Border = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.st_PLCLS.Caption = "PLC-LS";
            this.st_PLCLS.Id = 14;
            this.st_PLCLS.ImageOptions.Image = global::Baodongchem.Properties.Resources.PLC;
            this.st_PLCLS.ItemAppearance.Normal.BackColor = System.Drawing.Color.Red;
            this.st_PLCLS.ItemAppearance.Normal.ForeColor = System.Drawing.Color.White;
            this.st_PLCLS.ItemAppearance.Normal.Options.UseBackColor = true;
            this.st_PLCLS.ItemAppearance.Normal.Options.UseForeColor = true;
            this.st_PLCLS.Name = "st_PLCLS";
            this.st_PLCLS.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // st_PLCAB
            // 
            this.st_PLCAB.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.st_PLCAB.Border = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.st_PLCAB.Caption = "PLC-AB";
            this.st_PLCAB.Id = 15;
            this.st_PLCAB.ImageOptions.Image = global::Baodongchem.Properties.Resources.PLC;
            this.st_PLCAB.ItemAppearance.Normal.BackColor = System.Drawing.Color.Red;
            this.st_PLCAB.ItemAppearance.Normal.ForeColor = System.Drawing.Color.White;
            this.st_PLCAB.ItemAppearance.Normal.Options.UseBackColor = true;
            this.st_PLCAB.ItemAppearance.Normal.Options.UseForeColor = true;
            this.st_PLCAB.Name = "st_PLCAB";
            this.st_PLCAB.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // st_PLCOM
            // 
            this.st_PLCOM.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.st_PLCOM.Border = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.st_PLCOM.Caption = "PLC-Om";
            this.st_PLCOM.Id = 17;
            this.st_PLCOM.ImageOptions.Image = global::Baodongchem.Properties.Resources.PLC;
            this.st_PLCOM.ItemAppearance.Normal.BackColor = System.Drawing.Color.Red;
            this.st_PLCOM.ItemAppearance.Normal.ForeColor = System.Drawing.Color.White;
            this.st_PLCOM.ItemAppearance.Normal.Options.UseBackColor = true;
            this.st_PLCOM.ItemAppearance.Normal.Options.UseForeColor = true;
            this.st_PLCOM.Name = "st_PLCOM";
            this.st_PLCOM.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.st_PLCOM.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barStaticItem1_ItemClick);
            // 
            // st_THD
            // 
            this.st_THD.AutoSize = DevExpress.XtraBars.BarStaticItemSize.None;
            this.st_THD.Border = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.st_THD.Caption = "THD";
            this.st_THD.Id = 19;
            this.st_THD.ImageOptions.Image = global::Baodongchem.Properties.Resources.temperature_inside_18px;
            this.st_THD.ItemAppearance.Normal.BackColor = System.Drawing.Color.Red;
            this.st_THD.ItemAppearance.Normal.ForeColor = System.Drawing.Color.White;
            this.st_THD.ItemAppearance.Normal.Options.UseBackColor = true;
            this.st_THD.ItemAppearance.Normal.Options.UseForeColor = true;
            this.st_THD.Name = "st_THD";
            this.st_THD.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.st_THD.Size = new System.Drawing.Size(80, 0);
            this.st_THD.Width = 80;
            this.st_THD.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.st_THD_ItemClick);
            // 
            // bt_Setting
            // 
            this.bt_Setting.Caption = "Setting";
            this.bt_Setting.Id = 16;
            this.bt_Setting.ImageOptions.Image = global::Baodongchem.Properties.Resources.settings_18px;
            this.bt_Setting.Name = "bt_Setting";
            this.bt_Setting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_Setting_ItemClick);
            // 
            // bt_Calibration
            // 
            this.bt_Calibration.Caption = "Calibration";
            this.bt_Calibration.Id = 18;
            this.bt_Calibration.ImageOptions.Image = global::Baodongchem.Properties.Resources.caliper_18px;
            this.bt_Calibration.Name = "bt_Calibration";
            this.bt_Calibration.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_Calibration_ItemClick);
            // 
            // btGioithieu
            // 
            this.btGioithieu.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btGioithieu.Caption = "About";
            this.btGioithieu.Id = 12;
            this.btGioithieu.ImageOptions.Image = global::Baodongchem.Properties.Resources.noti_info_18;
            this.btGioithieu.Name = "btGioithieu";
            this.btGioithieu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btGioithieu_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barDockControlTop.Appearance.Options.UseFont = true;
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlTop.Size = new System.Drawing.Size(1440, 38);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 820);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1440, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 38);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 782);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1440, 38);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 782);
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 2";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Custom 2";
            // 
            // bar2
            // 
            this.bar2.BarName = "Custom 3";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 1;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.Text = "Custom 3";
            // 
            // bar3
            // 
            this.bar3.BarName = "Custom 2";
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar3.Text = "Custom 2";
            // 
            // bar4
            // 
            this.bar4.BarName = "Custom 2";
            this.bar4.DockCol = 0;
            this.bar4.DockRow = 0;
            this.bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar4.OptionsBar.MultiLine = true;
            this.bar4.OptionsBar.UseWholeRow = true;
            this.bar4.Text = "Custom 2";
            // 
            // bar5
            // 
            this.bar5.BarName = "Custom 3";
            this.bar5.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar5.DockCol = 0;
            this.bar5.DockRow = 0;
            this.bar5.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar5.OptionsBar.AllowQuickCustomization = false;
            this.bar5.OptionsBar.DrawDragBorder = false;
            this.bar5.OptionsBar.UseWholeRow = true;
            this.bar5.Text = "Custom 3";
            // 
            // bar6
            // 
            this.bar6.BarName = "Custom 4";
            this.bar6.DockCol = 0;
            this.bar6.DockRow = 1;
            this.bar6.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar6.Text = "Custom 4";
            // 
            // bar8
            // 
            this.bar8.BarName = "Custom 3";
            this.bar8.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar8.DockCol = 0;
            this.bar8.DockRow = 0;
            this.bar8.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar8.OptionsBar.AllowQuickCustomization = false;
            this.bar8.OptionsBar.DrawDragBorder = false;
            this.bar8.OptionsBar.UseWholeRow = true;
            this.bar8.Text = "Custom 3";
            // 
            // bar9
            // 
            this.bar9.BarName = "Custom 4";
            this.bar9.DockCol = 0;
            this.bar9.DockRow = 1;
            this.bar9.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar9.Text = "Custom 4";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabMain, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 38);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1440, 782);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.BT_RESET_AL, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.BT_TATCOI, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.bt_Report, 0, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(1293, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 7;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(144, 776);
            this.tableLayoutPanel4.TabIndex = 7;
            this.tableLayoutPanel4.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel4_Paint);
            // 
            // BT_RESET_AL
            // 
            this.BT_RESET_AL.BackColor = System.Drawing.Color.Gainsboro;
            this.BT_RESET_AL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BT_RESET_AL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_RESET_AL.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_RESET_AL.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.BT_RESET_AL.Image = global::Baodongchem.Properties.Resources.reset_32px;
            this.BT_RESET_AL.Location = new System.Drawing.Point(3, 113);
            this.BT_RESET_AL.Name = "BT_RESET_AL";
            this.BT_RESET_AL.Size = new System.Drawing.Size(138, 104);
            this.BT_RESET_AL.TabIndex = 1;
            this.BT_RESET_AL.Text = "RESET ALARM";
            this.BT_RESET_AL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BT_RESET_AL.UseVisualStyleBackColor = false;
            this.BT_RESET_AL.Click += new System.EventHandler(this.BT_RESET_AL_Click);
            // 
            // BT_TATCOI
            // 
            this.BT_TATCOI.BackColor = System.Drawing.Color.Gainsboro;
            this.BT_TATCOI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BT_TATCOI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_TATCOI.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_TATCOI.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.BT_TATCOI.Image = global::Baodongchem.Properties.Resources.mute_32px;
            this.BT_TATCOI.Location = new System.Drawing.Point(3, 3);
            this.BT_TATCOI.Name = "BT_TATCOI";
            this.BT_TATCOI.Size = new System.Drawing.Size(138, 104);
            this.BT_TATCOI.TabIndex = 0;
            this.BT_TATCOI.Text = "MUTE";
            this.BT_TATCOI.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BT_TATCOI.UseVisualStyleBackColor = false;
            this.BT_TATCOI.Click += new System.EventHandler(this.BT_TATCOI_Click);
            // 
            // bt_Report
            // 
            this.bt_Report.BackColor = System.Drawing.Color.Gainsboro;
            this.bt_Report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_Report.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Report.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Report.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.bt_Report.Image = global::Baodongchem.Properties.Resources.report_file_32px;
            this.bt_Report.Location = new System.Drawing.Point(3, 223);
            this.bt_Report.Name = "bt_Report";
            this.bt_Report.Size = new System.Drawing.Size(138, 104);
            this.bt_Report.TabIndex = 8;
            this.bt_Report.Text = "REPORT";
            this.bt_Report.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bt_Report.UseVisualStyleBackColor = false;
            this.bt_Report.Click += new System.EventHandler(this.bt_Report_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btPack, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.bt_MccRoom, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.bt_Rto, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.bt_FumeDust, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.bt_AirPressure, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.bt_VaccumPump, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.bt_Waterpump, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(144, 776);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // btPack
            // 
            this.btPack.BackColor = System.Drawing.Color.Gainsboro;
            this.btPack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btPack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPack.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPack.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btPack.Image = global::Baodongchem.Properties.Resources.gProduct_181;
            this.btPack.Location = new System.Drawing.Point(3, 663);
            this.btPack.Name = "btPack";
            this.btPack.Size = new System.Drawing.Size(138, 110);
            this.btPack.TabIndex = 9;
            this.btPack.Text = "PACK";
            this.btPack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btPack.UseVisualStyleBackColor = false;
            this.btPack.Click += new System.EventHandler(this.btPack_Click);
            // 
            // bt_MccRoom
            // 
            this.bt_MccRoom.BackColor = System.Drawing.Color.Gainsboro;
            this.bt_MccRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_MccRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_MccRoom.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_MccRoom.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.bt_MccRoom.Image = global::Baodongchem.Properties.Resources.earth_planet_32px;
            this.bt_MccRoom.Location = new System.Drawing.Point(3, 553);
            this.bt_MccRoom.Name = "bt_MccRoom";
            this.bt_MccRoom.Size = new System.Drawing.Size(138, 104);
            this.bt_MccRoom.TabIndex = 5;
            this.bt_MccRoom.Text = "MCC ROOM";
            this.bt_MccRoom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bt_MccRoom.UseVisualStyleBackColor = false;
            this.bt_MccRoom.Click += new System.EventHandler(this.bt_MccRoom_Click);
            // 
            // bt_Rto
            // 
            this.bt_Rto.BackColor = System.Drawing.Color.Gainsboro;
            this.bt_Rto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_Rto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Rto.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Rto.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.bt_Rto.Image = global::Baodongchem.Properties.Resources.temperature_outside_32px;
            this.bt_Rto.Location = new System.Drawing.Point(3, 443);
            this.bt_Rto.Name = "bt_Rto";
            this.bt_Rto.Size = new System.Drawing.Size(138, 104);
            this.bt_Rto.TabIndex = 4;
            this.bt_Rto.Text = "RTO";
            this.bt_Rto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bt_Rto.UseVisualStyleBackColor = false;
            this.bt_Rto.Click += new System.EventHandler(this.bt_Rto_Click);
            // 
            // bt_FumeDust
            // 
            this.bt_FumeDust.BackColor = System.Drawing.Color.Gainsboro;
            this.bt_FumeDust.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_FumeDust.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_FumeDust.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_FumeDust.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.bt_FumeDust.Image = global::Baodongchem.Properties.Resources.temperature_low_32px;
            this.bt_FumeDust.Location = new System.Drawing.Point(3, 333);
            this.bt_FumeDust.Name = "bt_FumeDust";
            this.bt_FumeDust.Size = new System.Drawing.Size(138, 104);
            this.bt_FumeDust.TabIndex = 3;
            this.bt_FumeDust.Text = "FUME DUST";
            this.bt_FumeDust.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bt_FumeDust.UseVisualStyleBackColor = false;
            this.bt_FumeDust.Click += new System.EventHandler(this.bt_FumeDust_Click);
            // 
            // bt_AirPressure
            // 
            this.bt_AirPressure.BackColor = System.Drawing.Color.Gainsboro;
            this.bt_AirPressure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_AirPressure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_AirPressure.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_AirPressure.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.bt_AirPressure.Image = global::Baodongchem.Properties.Resources.pressure_gauge_32px;
            this.bt_AirPressure.Location = new System.Drawing.Point(3, 223);
            this.bt_AirPressure.Name = "bt_AirPressure";
            this.bt_AirPressure.Size = new System.Drawing.Size(138, 104);
            this.bt_AirPressure.TabIndex = 2;
            this.bt_AirPressure.Text = "AIR PRESSURE";
            this.bt_AirPressure.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bt_AirPressure.UseVisualStyleBackColor = false;
            this.bt_AirPressure.Click += new System.EventHandler(this.bt_AirPressure_Click);
            // 
            // bt_VaccumPump
            // 
            this.bt_VaccumPump.BackColor = System.Drawing.Color.Gainsboro;
            this.bt_VaccumPump.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_VaccumPump.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_VaccumPump.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_VaccumPump.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.bt_VaccumPump.Image = global::Baodongchem.Properties.Resources.air_32px;
            this.bt_VaccumPump.Location = new System.Drawing.Point(3, 113);
            this.bt_VaccumPump.Name = "bt_VaccumPump";
            this.bt_VaccumPump.Size = new System.Drawing.Size(138, 104);
            this.bt_VaccumPump.TabIndex = 1;
            this.bt_VaccumPump.Text = "VACCUM PUMP";
            this.bt_VaccumPump.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bt_VaccumPump.UseVisualStyleBackColor = false;
            this.bt_VaccumPump.Click += new System.EventHandler(this.bt_VaccumPump_Click);
            // 
            // bt_Waterpump
            // 
            this.bt_Waterpump.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.bt_Waterpump.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_Waterpump.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Waterpump.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Waterpump.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.bt_Waterpump.Image = global::Baodongchem.Properties.Resources.pump_32px;
            this.bt_Waterpump.Location = new System.Drawing.Point(3, 3);
            this.bt_Waterpump.Name = "bt_Waterpump";
            this.bt_Waterpump.Size = new System.Drawing.Size(138, 104);
            this.bt_Waterpump.TabIndex = 0;
            this.bt_Waterpump.Text = "WATER PUMP";
            this.bt_Waterpump.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bt_Waterpump.UseVisualStyleBackColor = false;
            this.bt_Waterpump.Click += new System.EventHandler(this.bt_Waterpump_Click);
            // 
            // timer_excel_real
            // 
            this.timer_excel_real.Enabled = true;
            this.timer_excel_real.Interval = 5000;
            this.timer_excel_real.Tick += new System.EventHandler(this.timer_excel_real_Tick);
            // 
            // tabMain
            // 
            this.tabMain.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(55)))), ((int)(((byte)(111)))));
            this.tabMain.Appearance.Options.UseBackColor = true;
            this.tabMain.AppearancePage.HeaderActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(55)))), ((int)(((byte)(111)))));
            this.tabMain.AppearancePage.HeaderActive.Options.UseBackColor = true;
            this.tabMain.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(149, 4);
            this.tabMain.Margin = new System.Windows.Forms.Padding(4);
            this.tabMain.Name = "tabMain";
            this.tabMain.Size = new System.Drawing.Size(1142, 774);
            this.tabMain.TabIndex = 5;
            // 
            // Form1
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 820);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống báo động tập trung";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer Timer_display;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        private System.Windows.Forms.Timer Timer_loaddata;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Bar bar10;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.Bar bar4;
        private DevExpress.XtraBars.Bar bar5;
        private DevExpress.XtraBars.Bar bar6;
        private DevExpress.XtraBars.Bar bar8;
        private DevExpress.XtraBars.Bar bar9;
        private DevExpress.XtraBars.BarSubItem btGioithieu;
        private DevExpress.XtraBars.BarStaticItem st_PLCSI;
        private DevExpress.XtraBars.BarStaticItem st_PLCLS;
        private DevExpress.XtraBars.BarStaticItem st_PLCAB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button bt_Waterpump;
        private System.Windows.Forms.Button bt_MccRoom;
        private System.Windows.Forms.Button bt_Rto;
        private System.Windows.Forms.Button bt_FumeDust;
        private System.Windows.Forms.Button bt_AirPressure;
        private System.Windows.Forms.Button bt_VaccumPump;
        private DevExpress.XtraBars.BarButtonItem bt_Setting;
        private DevExpress.XtraBars.BarStaticItem st_PLCOM;
        private DevExpress.XtraBars.BarButtonItem bt_Calibration;
        private System.Windows.Forms.Timer timer_excel_real;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button BT_RESET_AL;
        private System.Windows.Forms.Button BT_TATCOI;
        private DevExpress.XtraBars.BarStaticItem st_THD;
        private System.Windows.Forms.Button bt_Report;
        private System.Windows.Forms.Button btPack;
        private DevExpress.XtraBars.BarStaticItem st_PLCSIPACK;
        private DevExpress.XtraTab.XtraTabControl tabMain;
    }
}

