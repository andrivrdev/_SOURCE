﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Shared.wsServer {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://avrcomms/server/api", ConfigurationName="wsServer.wsServerSoap")]
    public interface wsServerSoap {
        
        // CODEGEN: Generating message contract since element name xData from namespace http://avrcomms/server/api is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://avrcomms/server/api/GetWork", ReplyAction="*")]
        Shared.wsServer.GetWorkResponse GetWork(Shared.wsServer.GetWorkRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://avrcomms/server/api/GetWork", ReplyAction="*")]
        System.Threading.Tasks.Task<Shared.wsServer.GetWorkResponse> GetWorkAsync(Shared.wsServer.GetWorkRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetWorkRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetWork", Namespace="http://avrcomms/server/api", Order=0)]
        public Shared.wsServer.GetWorkRequestBody Body;
        
        public GetWorkRequest() {
        }
        
        public GetWorkRequest(Shared.wsServer.GetWorkRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://avrcomms/server/api")]
    public partial class GetWorkRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string xData;
        
        public GetWorkRequestBody() {
        }
        
        public GetWorkRequestBody(string xData) {
            this.xData = xData;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetWorkResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetWorkResponse", Namespace="http://avrcomms/server/api", Order=0)]
        public Shared.wsServer.GetWorkResponseBody Body;
        
        public GetWorkResponse() {
        }
        
        public GetWorkResponse(Shared.wsServer.GetWorkResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://avrcomms/server/api")]
    public partial class GetWorkResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string GetWorkResult;
        
        public GetWorkResponseBody() {
        }
        
        public GetWorkResponseBody(string GetWorkResult) {
            this.GetWorkResult = GetWorkResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface wsServerSoapChannel : Shared.wsServer.wsServerSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class wsServerSoapClient : System.ServiceModel.ClientBase<Shared.wsServer.wsServerSoap>, Shared.wsServer.wsServerSoap {
        
        public wsServerSoapClient() {
        }
        
        public wsServerSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public wsServerSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public wsServerSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public wsServerSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Shared.wsServer.GetWorkResponse Shared.wsServer.wsServerSoap.GetWork(Shared.wsServer.GetWorkRequest request) {
            return base.Channel.GetWork(request);
        }
        
        public string GetWork(string xData) {
            Shared.wsServer.GetWorkRequest inValue = new Shared.wsServer.GetWorkRequest();
            inValue.Body = new Shared.wsServer.GetWorkRequestBody();
            inValue.Body.xData = xData;
            Shared.wsServer.GetWorkResponse retVal = ((Shared.wsServer.wsServerSoap)(this)).GetWork(inValue);
            return retVal.Body.GetWorkResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Shared.wsServer.GetWorkResponse> Shared.wsServer.wsServerSoap.GetWorkAsync(Shared.wsServer.GetWorkRequest request) {
            return base.Channel.GetWorkAsync(request);
        }
        
        public System.Threading.Tasks.Task<Shared.wsServer.GetWorkResponse> GetWorkAsync(string xData) {
            Shared.wsServer.GetWorkRequest inValue = new Shared.wsServer.GetWorkRequest();
            inValue.Body = new Shared.wsServer.GetWorkRequestBody();
            inValue.Body.xData = xData;
            return ((Shared.wsServer.wsServerSoap)(this)).GetWorkAsync(inValue);
        }
    }
}
