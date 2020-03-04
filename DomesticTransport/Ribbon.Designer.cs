﻿namespace DomesticTransport
{
    partial class Ribbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ribbon));
            this.ShefflerRibbon = this.Factory.CreateRibbonTab();
            this.groupGeneral = this.Factory.CreateRibbonGroup();
            this.btnStart = this.Factory.CreateRibbonButton();
            this.groupEdit = this.Factory.CreateRibbonGroup();
            this.btnChangePoint = this.Factory.CreateRibbonButton();
            this.btnChangeSet = this.Factory.CreateRibbonButton();
            this.btnAcept = this.Factory.CreateRibbonButton();
            this.groupMap = this.Factory.CreateRibbonGroup();
            this.btnMap = this.Factory.CreateRibbonButton();
            this.ShefflerRibbon.SuspendLayout();
            this.groupGeneral.SuspendLayout();
            this.groupEdit.SuspendLayout();
            this.groupMap.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShefflerRibbon
            // 
            this.ShefflerRibbon.Groups.Add(this.groupGeneral);
            this.ShefflerRibbon.Groups.Add(this.groupEdit);
            this.ShefflerRibbon.Groups.Add(this.groupMap);
            this.ShefflerRibbon.Label = "Шеффлер";
            this.ShefflerRibbon.Name = "ShefflerRibbon";
            this.ShefflerRibbon.Position = this.Factory.RibbonPosition.BeforeOfficeId("TabHome");
            // 
            // groupGeneral
            // 
            this.groupGeneral.Items.Add(this.btnStart);
            this.groupGeneral.Items.Add(this.btnAcept);
            this.groupGeneral.Label = "Список";
            this.groupGeneral.Name = "groupGeneral";
            // 
            // btnStart
            // 
            this.btnStart.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
            this.btnStart.Label = "Формировать список доставок";
            this.btnStart.Name = "btnStart";
            this.btnStart.ShowImage = true;
            this.btnStart.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnStart_Click);
            // 
            // groupEdit
            // 
            this.groupEdit.Items.Add(this.btnChangeSet);
            this.groupEdit.Items.Add(this.btnChangePoint);
            this.groupEdit.Label = "Редактирование";
            this.groupEdit.Name = "groupEdit";
            // 
            // btnChangePoint
            // 
            this.btnChangePoint.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnChangePoint.Image = ((System.Drawing.Image)(resources.GetObject("btnChangePoint.Image")));
            this.btnChangePoint.Label = "Изменить маршрут";
            this.btnChangePoint.Name = "btnChangePoint";
            this.btnChangePoint.ShowImage = true;
            // 
            // btnChangeSet
            // 
            this.btnChangeSet.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnChangeSet.Image = ((System.Drawing.Image)(resources.GetObject("btnChangeSet.Image")));
            this.btnChangeSet.Label = "Изменить набор";
            this.btnChangeSet.Name = "btnChangeSet";
            this.btnChangeSet.ShowImage = true;
            // 
            // btnAcept
            // 
            this.btnAcept.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnAcept.Image = ((System.Drawing.Image)(resources.GetObject("btnAcept.Image")));
            this.btnAcept.Label = "Принять ";
            this.btnAcept.Name = "btnAcept";
            this.btnAcept.ShowImage = true;
            // 
            // groupMap
            // 
            this.groupMap.Items.Add(this.btnMap);
            this.groupMap.Label = "Карта";
            this.groupMap.Name = "groupMap";
            // 
            // btnMap
            // 
            this.btnMap.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnMap.Image = ((System.Drawing.Image)(resources.GetObject("btnMap.Image")));
            this.btnMap.Label = "Показать маршрут";
            this.btnMap.Name = "btnMap";
            this.btnMap.ShowImage = true;
            // 
            // Ribbon
            // 
            this.Name = "Ribbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.ShefflerRibbon);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon_Load);
            this.ShefflerRibbon.ResumeLayout(false);
            this.ShefflerRibbon.PerformLayout();
            this.groupGeneral.ResumeLayout(false);
            this.groupGeneral.PerformLayout();
            this.groupEdit.ResumeLayout(false);
            this.groupEdit.PerformLayout();
            this.groupMap.ResumeLayout(false);
            this.groupMap.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupGeneral;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnStart;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupEdit;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnChangePoint;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnAcept;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnChangeSet;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupMap;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnMap;
        internal Microsoft.Office.Tools.Ribbon.RibbonTab ShefflerRibbon;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon Ribbon
        {
            get { return this.GetRibbon<Ribbon>(); }
        }
    }
}
