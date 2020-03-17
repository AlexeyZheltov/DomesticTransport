﻿namespace DomesticTransport
{
    partial class RibbonDelivery : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RibbonDelivery()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RibbonDelivery));
            this.ShefflerRibbon = this.Factory.CreateRibbonTab();
            this.groupGeneral = this.Factory.CreateRibbonGroup();
            this.btnStart = this.Factory.CreateRibbonButton();
            this.btnAcept = this.Factory.CreateRibbonButton();
            this.groupEdit = this.Factory.CreateRibbonGroup();
            this.btnChangeSet = this.Factory.CreateRibbonButton();
            this.btnChangePoint = this.Factory.CreateRibbonButton();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.btnSendShippingCompany = this.Factory.CreateRibbonButton();
            this.btnReadCarrierInvoice = this.Factory.CreateRibbonButton();
            this.settings = this.Factory.CreateRibbonGroup();
            this.btnSetts = this.Factory.CreateRibbonButton();
            this.about = this.Factory.CreateRibbonGroup();
            this.btnAboutProgrramm = this.Factory.CreateRibbonButton();
            this.ShefflerRibbon.SuspendLayout();
            this.groupGeneral.SuspendLayout();
            this.groupEdit.SuspendLayout();
            this.group1.SuspendLayout();
            this.settings.SuspendLayout();
            this.about.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShefflerRibbon
            // 
            this.ShefflerRibbon.Groups.Add(this.groupGeneral);
            this.ShefflerRibbon.Groups.Add(this.groupEdit);
            this.ShefflerRibbon.Groups.Add(this.group1);
            this.ShefflerRibbon.Groups.Add(this.settings);
            this.ShefflerRibbon.Groups.Add(this.about);
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
            // btnAcept
            // 
            this.btnAcept.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnAcept.Image = ((System.Drawing.Image)(resources.GetObject("btnAcept.Image")));
            this.btnAcept.Label = "Принять ";
            this.btnAcept.Name = "btnAcept";
            this.btnAcept.ShowImage = true;
            this.btnAcept.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnAcept_Click);
            // 
            // groupEdit
            // 
            this.groupEdit.Items.Add(this.btnChangeSet);
            this.groupEdit.Items.Add(this.btnChangePoint);
            this.groupEdit.Label = "Редактирование";
            this.groupEdit.Name = "groupEdit";
            this.groupEdit.Visible = false;
            // 
            // btnChangeSet
            // 
            this.btnChangeSet.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnChangeSet.Image = ((System.Drawing.Image)(resources.GetObject("btnChangeSet.Image")));
            this.btnChangeSet.Label = "Изменить набор";
            this.btnChangeSet.Name = "btnChangeSet";
            this.btnChangeSet.ShowImage = true;
            this.btnChangeSet.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnChangeSet_Click);
            // 
            // btnChangePoint
            // 
            this.btnChangePoint.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnChangePoint.Image = ((System.Drawing.Image)(resources.GetObject("btnChangePoint.Image")));
            this.btnChangePoint.Label = "Изменить маршрут";
            this.btnChangePoint.Name = "btnChangePoint";
            this.btnChangePoint.ShowImage = true;
            this.btnChangePoint.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnChangePoint_Click);
            // 
            // group1
            // 
            this.group1.Items.Add(this.btnSendShippingCompany);
            this.group1.Items.Add(this.btnReadCarrierInvoice);
            this.group1.Label = "Сообщения";
            this.group1.Name = "group1";
            this.group1.Visible = false;
            // 
            // btnSendShippingCompany
            // 
            this.btnSendShippingCompany.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnSendShippingCompany.Image = ((System.Drawing.Image)(resources.GetObject("btnSendShippingCompany.Image")));
            this.btnSendShippingCompany.Label = "Заказать перевозку";
            this.btnSendShippingCompany.Name = "btnSendShippingCompany";
            this.btnSendShippingCompany.ShowImage = true;
            this.btnSendShippingCompany.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnSendShippingCompany_Click);
            // 
            // btnReadCarrierInvoice
            // 
            this.btnReadCarrierInvoice.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnReadCarrierInvoice.Image = ((System.Drawing.Image)(resources.GetObject("btnReadCarrierInvoice.Image")));
            this.btnReadCarrierInvoice.Label = "Сканировать ответ";
            this.btnReadCarrierInvoice.Name = "btnReadCarrierInvoice";
            this.btnReadCarrierInvoice.ShowImage = true;
            // 
            // settings
            // 
            this.settings.Items.Add(this.btnSetts);
            this.settings.Label = "Настройки";
            this.settings.Name = "settings";
            this.settings.Visible = false;
            // 
            // btnSetts
            // 
            this.btnSetts.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnSetts.Image = ((System.Drawing.Image)(resources.GetObject("btnSetts.Image")));
            this.btnSetts.Label = "Настройки";
            this.btnSetts.Name = "btnSetts";
            this.btnSetts.ShowImage = true;
            // 
            // about
            // 
            this.about.Items.Add(this.btnAboutProgrramm);
            this.about.Label = "Справка";
            this.about.Name = "about";
            this.about.Visible = false;
            // 
            // btnAboutProgrramm
            // 
            this.btnAboutProgrramm.Image = ((System.Drawing.Image)(resources.GetObject("btnAboutProgrramm.Image")));
            this.btnAboutProgrramm.Label = "О программе";
            this.btnAboutProgrramm.Name = "btnAboutProgrramm";
            this.btnAboutProgrramm.ShowImage = true;
            // 
            // RibbonDelivery
            // 
            this.Name = "RibbonDelivery";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.ShefflerRibbon);
            this.ShefflerRibbon.ResumeLayout(false);
            this.ShefflerRibbon.PerformLayout();
            this.groupGeneral.ResumeLayout(false);
            this.groupGeneral.PerformLayout();
            this.groupEdit.ResumeLayout(false);
            this.groupEdit.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.settings.ResumeLayout(false);
            this.settings.PerformLayout();
            this.about.ResumeLayout(false);
            this.about.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupGeneral;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnStart;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupEdit;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnChangePoint;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnAcept;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnChangeSet;
        internal Microsoft.Office.Tools.Ribbon.RibbonTab ShefflerRibbon;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSendShippingCompany;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnReadCarrierInvoice;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup settings;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSetts;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup about;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnAboutProgrramm;
    }

    partial class ThisRibbonCollection
    {
        internal RibbonDelivery Ribbon
        {
            get { return this.GetRibbon<RibbonDelivery>(); }
        }
    }
}
