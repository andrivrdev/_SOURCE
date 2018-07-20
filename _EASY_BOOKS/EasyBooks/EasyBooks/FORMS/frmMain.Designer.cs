<?xml version="1.0" encoding="utf-8"?>
<!--
  For more information on how to configure your ASP.NET application, please visit
  http://go.microsoft.com/fwlink/?LinkId=152368
  -->
<configuration>
  <configSections>
    <sectionGroup name="devExpress">
      <section name="themes" type="DevExpress.Web.ThemesConfigurationSection, DevExpress.Web.v17.1, Version=17.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" requirePermission="false" />
      <section name="compression" type="DevExpress.Web.CompressionConfigurationSection, DevExpress.Web.v17.1, Version=17.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" requirePermission="false" />
      <section name="settings" type="DevExpress.Web.SettingsConfigurationSection, DevExpress.Web.v17.1, Version=17.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" requirePermission="false" />
      <section name="errors" type="DevExpress.Web.ErrorsConfigurationSection, DevExpress.Web.v17.1, Version=17.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" requirePermission="false" />
      <section name="resources" type="DevExpress.Web.ResourcesConfigurationSection, DevExpress.Web.v17.1, Version=17.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" requirePermission="false" />
    </sectionGroup>
  </configSections>
  <connectionStrings>
    <add name="DefaultConnection" connectionString="data source=(localdb)\mssqllocaldb;initial catalog=aspnet-MixingMVCandASPX-20180748101548;integrated security=SSPI" providerName="System.Data.SqlClient" />
  </connectionStrings>
  <appSettings>
    <add key="webpages:Version" value="3.0.0.0" />
    <add key="webpages:Enabled" value="false" />
    <add key="PreserveLoginUrl" value="true" />
    <add key="ClientValidationEnabled" value="true" />
    <add key="UnobtrusiveJavaScriptEnabled" value="true" />
    <add key="vs:EnableBrowserLink" value="false" />
  </appSettings>
  <system.web>
    <compilation debug="true" targetFramework="4.5">
      <assemblies>
        <add assembly="System.Web.Abstractions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
        <add assembly="System.Web.Routing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
        <add assembly="DevExpress.Utils.v17.1, Version=17.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" />
        <add assembly="DevExpress.Data.v17.1, Version=17.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" />
        <add assembly="DevExpress.Web.ASPxThemes.v17.1, Version=17.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" />
        <add assembly="DevExpress.RichEdit.v17.1.Core, Version=17.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" />
        <add assembly="DevExpress.Printing.v17.1.Core, Version=17.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" />
        <add assembly="DevExpress.Web.v17.1, Version=17.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" />
        <add assembly="DevExpress.Web.Mvc5.v17.1, Version=17.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" />
        <add assembly="DevExpress.Web.Bootstrap.v17.1, Version=17.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" />
      </assemblies>
    </compilation>
    <authentication mode="None" />
    <pages validateRequest="true" clientIDMode="Predictable">
      <controls>
        <add tagPrefix="dx" namespace="DevExpress.Web" assembly="DevExpress.Web.v17.1, Version=17.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" />
        <add tagPrefix="dx" namespace="DevExpress.Web.Bootstrap" assembly="DevExpress.Web.Bootstrap.v17.1, Version=17.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" />
      </controls>
      <namespaces>
        <add namespace="System.Web.Helpers" />
        <add namespace="System.Web.Mvc" />
        <add namespace="System.Web.Mvc.Ajax" />
        <add namespace="System.Web.Mvc.Html" />
        <add namespace="System.Web.Routing" />
        <add namespace="System.Web.WebPages" />
        <add namespace="System.Web.UI.WebControls" />
        <add namespace="DevExpress.Utils" />
        <add namespace="DevExpress.Web.ASPxThemes" />
        <add namespace="DevExpress.Web" />
        <add namespace="DevExpress.Web.Mvc" />
        <add namespace="DevExpress.Web.Mvc.UI" />
      </namespaces>
    </pages>
    <httpHandlers>
      <add type="DevExpress.Web.ASPxUploadProgressHttpHandler, DevExpress.Web.v17.1, Version=17.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" verb="GET,POST" path="ASPxUploadProgressHandlerPage.ashx" validate="false" />
      <add type="DevExpress.Web.ASPxHttpHandlerModule, DevExpress.Web.v17.1, Version=17.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" verb="GET" path="DX.ashx" validate="false" />
    </httpHandlers>
    <httpModules>
      <add type="DevExpress.Web.ASPxHttpHandlerModule, DevExpress.Web.v17.1, Version=17.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" name="ASPxHttpHandlerModule" />
    </httpModules>
    <globalization culture="" uiCulture="" />
    <httpRuntime maxRequestLength="4096" requestValidationMode="4.0" executionTimeout="110" targetFramework="4.5" />
  </system.web>
  <system.webServer>
    <validation validateIntegratedModeConfiguration="false" />
    <modules runAllManagedModulesForAllRequests="true">
      <add type="DevExpress.Web.ASPxHttpHandlerModule, DevExpress.Web.v17.1, Version=17.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" name="ASPxHttpHandlerModule" />
    </modules>
    <handlers>
      <add type="DevExpress.Web.ASPxUploadProgressHttpHandler, DevExpress.Web.v17.1, Version=17.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" verb="GET,POST" path="ASPxUploadProgressHandlerPage.ashx" name="ASPxUploadProgressHandler" preCondition="integratedMode" />
      <add type="DevExpress.Web.ASPxHttpHandlerModule, DevExpress.Web.v17.1, Version=17.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" verb="GET" path="DX.ashx" name="ASPxHttpHandlerModule" preCondition="integratedMode" />
    </handlers>
    <security>
      <requestFiltering>
        <requestLimits maxAllowedContentLength="30000000" />
      </requestFiltering>
    </security>
  </system.webServer>
  <runtime>
    <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
      <dependentAssembly>
        <assemblyIdentity name="System.Web.Helpers" publicKeyToken="31bf3856ad364e35" />
        <bindingRedirect oldVersion="1.0.0.0-3.0.0.0" newVersion="3.0.0.0" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="System.Web.Mvc" publicKeyToken="31bf3856ad364e35" />
        <bindingRedirect oldVersion="0.0.0.0-5.2.3.0" newVersion="5.2.3.0" />
      </dependentAssembly>
      <dependentAssembly>
        <assemblyIdentity name="System.Web.WebPages" publicKeyToken="31bf3856ad364e35" />
        <bindingRedirect oldVersion="1.0.0.0-3.0.0.0" newVersion="3.0.0.0" />
      </dependentAssembly>
    </assemblyBinding>
  </runtime>
  <devExpress>
    <resources>
      <add type="ThirdParty" />
      <add type="DevExtreme" />
    </resources>
    <themes enableThemesAssembly="true" styleSheetTheme="" theme="Moderno" customThemeAssemblies="" baseColor="" font="" />
    <compression enableHtmlCompression="false" enableCallbackCompression="true" enableResourceCompression="true" enableResourceMerging="true" />
    <settings accessibilityCompliant="false" bootstrapMode="Bootstrap3" doctypeMode="Html5" rightToLeft="false" checkReferencesToExternalScripts="true" protectControlState="true" ieCompatibilityVersion="edge" />
    <errors callbackErrorRedirectUrl="" />
  </devExpress>
</configuration>