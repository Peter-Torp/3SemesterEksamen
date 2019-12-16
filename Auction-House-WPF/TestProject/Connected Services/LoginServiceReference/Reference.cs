﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestProject.LoginServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LoginServiceReference.ILoginService")]
    public interface ILoginService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginService/CreateLogin", ReplyAction="http://tempuri.org/ILoginService/CreateLoginResponse")]
        ServiceLayer.UserServiceReference.UserData CreateLogin(string password, ServiceLayer.UserServiceReference.UserData userData);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginService/CreateLogin", ReplyAction="http://tempuri.org/ILoginService/CreateLoginResponse")]
        System.Threading.Tasks.Task<ServiceLayer.UserServiceReference.UserData> CreateLoginAsync(string password, ServiceLayer.UserServiceReference.UserData userData);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginService/Verify", ReplyAction="http://tempuri.org/ILoginService/VerifyResponse")]
        bool Verify(string password, string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginService/Verify", ReplyAction="http://tempuri.org/ILoginService/VerifyResponse")]
        System.Threading.Tasks.Task<bool> VerifyAsync(string password, string userName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILoginServiceChannel : TestProject.LoginServiceReference.ILoginService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LoginServiceClient : System.ServiceModel.ClientBase<TestProject.LoginServiceReference.ILoginService>, TestProject.LoginServiceReference.ILoginService {
        
        public LoginServiceClient() {
        }
        
        public LoginServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LoginServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LoginServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LoginServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ServiceLayer.UserServiceReference.UserData CreateLogin(string password, ServiceLayer.UserServiceReference.UserData userData) {
            return base.Channel.CreateLogin(password, userData);
        }
        
        public System.Threading.Tasks.Task<ServiceLayer.UserServiceReference.UserData> CreateLoginAsync(string password, ServiceLayer.UserServiceReference.UserData userData) {
            return base.Channel.CreateLoginAsync(password, userData);
        }
        
        public bool Verify(string password, string userName) {
            return base.Channel.Verify(password, userName);
        }
        
        public System.Threading.Tasks.Task<bool> VerifyAsync(string password, string userName) {
            return base.Channel.VerifyAsync(password, userName);
        }
    }
}