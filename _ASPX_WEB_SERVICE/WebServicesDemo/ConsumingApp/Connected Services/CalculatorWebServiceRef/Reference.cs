﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsumingApp.CalculatorWebServiceRef {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://localhost/calculator/api", ConfigurationName="CalculatorWebServiceRef.CalculatorWebServiceSoap")]
    public interface CalculatorWebServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/calculator/api/Add", ReplyAction="*")]
        int Add(int xNumA, int xNumB);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/calculator/api/Add", ReplyAction="*")]
        System.Threading.Tasks.Task<int> AddAsync(int xNumA, int xNumB);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface CalculatorWebServiceSoapChannel : ConsumingApp.CalculatorWebServiceRef.CalculatorWebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CalculatorWebServiceSoapClient : System.ServiceModel.ClientBase<ConsumingApp.CalculatorWebServiceRef.CalculatorWebServiceSoap>, ConsumingApp.CalculatorWebServiceRef.CalculatorWebServiceSoap {
        
        public CalculatorWebServiceSoapClient() {
        }
        
        public CalculatorWebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CalculatorWebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CalculatorWebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CalculatorWebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int Add(int xNumA, int xNumB) {
            return base.Channel.Add(xNumA, xNumB);
        }
        
        public System.Threading.Tasks.Task<int> AddAsync(int xNumA, int xNumB) {
            return base.Channel.AddAsync(xNumA, xNumB);
        }
    }
}