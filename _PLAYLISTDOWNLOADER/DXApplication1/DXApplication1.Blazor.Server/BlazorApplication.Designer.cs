namespace DXApplication1.Blazor.Server {
    partial class DXApplication1BlazorApplication {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.module1 = new DevExpress.ExpressApp.SystemModule.SystemModule();
            this.module2 = new DevExpress.ExpressApp.Blazor.SystemModule.SystemBlazorModule();
            this.module3 = new DXApplication1.Module.DXApplication1Module();
            this.module4 = new DXApplication1.Module.Blazor.DXApplication1BlazorModule();
            this.objectsModule = new DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule();
            this.cloneObjectModule = new DevExpress.ExpressApp.CloneObject.CloneObjectModule();
            this.conditionalAppearanceModule = new DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule();
            this.dashboardsModule = new DevExpress.ExpressApp.Dashboards.DashboardsModule();
            this.dashboardsBlazorModule = new DevExpress.ExpressApp.Dashboards.Blazor.DashboardsBlazorModule();
            this.fileAttachmentsBlazorModule = new DevExpress.ExpressApp.FileAttachments.Blazor.FileAttachmentsBlazorModule();
            this.treeListEditorsModuleBase = new DevExpress.ExpressApp.TreeListEditors.TreeListEditorsModuleBase();
            this.viewVariantsModule = new DevExpress.ExpressApp.ViewVariantsModule.ViewVariantsModule();

            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();

            //
            // dashboardsModule
            //
            this.dashboardsModule.DashboardDataType = typeof(DevExpress.Persistent.BaseImpl.DashboardData);
            // 
            // DXApplication1BlazorApplication
            // 
            this.ApplicationName = "DXApplication1";
            this.CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.DatabaseSchema;
            this.Modules.Add(this.module1);
            this.Modules.Add(this.module2);
            this.Modules.Add(this.module3);
            this.Modules.Add(this.module4);
            this.Modules.Add(this.objectsModule);
            this.Modules.Add(this.cloneObjectModule);
            this.Modules.Add(this.conditionalAppearanceModule);
            this.Modules.Add(this.dashboardsModule);
            this.Modules.Add(this.dashboardsBlazorModule);
            this.Modules.Add(this.fileAttachmentsBlazorModule);
            this.Modules.Add(this.treeListEditorsModuleBase);
            this.Modules.Add(this.viewVariantsModule);
            this.DatabaseVersionMismatch += new System.EventHandler<DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs>(this.DXApplication1BlazorApplication_DatabaseVersionMismatch);

            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.ExpressApp.SystemModule.SystemModule module1;
        private DevExpress.ExpressApp.Blazor.SystemModule.SystemBlazorModule module2;
        private DXApplication1.Module.DXApplication1Module module3;
        private DXApplication1.Module.Blazor.DXApplication1BlazorModule module4;
        private DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule objectsModule;
        private DevExpress.ExpressApp.CloneObject.CloneObjectModule cloneObjectModule;
        private DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule conditionalAppearanceModule;
        private DevExpress.ExpressApp.Dashboards.DashboardsModule dashboardsModule;
        private DevExpress.ExpressApp.Dashboards.Blazor.DashboardsBlazorModule dashboardsBlazorModule;
        private DevExpress.ExpressApp.FileAttachments.Blazor.FileAttachmentsBlazorModule fileAttachmentsBlazorModule;
        private DevExpress.ExpressApp.TreeListEditors.TreeListEditorsModuleBase treeListEditorsModuleBase;
        private DevExpress.ExpressApp.ViewVariantsModule.ViewVariantsModule viewVariantsModule;
    }
}
