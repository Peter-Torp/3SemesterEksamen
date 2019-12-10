﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestProject.UserServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserServiceReference.IUserService")]
    public interface IUserService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUserById", ReplyAction="http://tempuri.org/IUserService/GetUserByIdResponse")]
        ServiceLayer.UserServiceReference.UserData GetUserById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUserById", ReplyAction="http://tempuri.org/IUserService/GetUserByIdResponse")]
        System.Threading.Tasks.Task<ServiceLayer.UserServiceReference.UserData> GetUserByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUserByUserName", ReplyAction="http://tempuri.org/IUserService/GetUserByUserNameResponse")]
        ServiceLayer.UserServiceReference.UserData GetUserByUserName(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUserByUserName", ReplyAction="http://tempuri.org/IUserService/GetUserByUserNameResponse")]
        System.Threading.Tasks.Task<ServiceLayer.UserServiceReference.UserData> GetUserByUserNameAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/InsertUser", ReplyAction="http://tempuri.org/IUserService/InsertUserResponse")]
        int InsertUser(string userName, string email, string phone, string zipCode, string region, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/InsertUser", ReplyAction="http://tempuri.org/IUserService/InsertUserResponse")]
        System.Threading.Tasks.Task<int> InsertUserAsync(string userName, string email, string phone, string zipCode, string region, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/TestString", ReplyAction="http://tempuri.org/IUserService/TestStringResponse")]
        string TestString();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/TestString", ReplyAction="http://tempuri.org/IUserService/TestStringResponse")]
        System.Threading.Tasks.Task<string> TestStringAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/CheckUserName", ReplyAction="http://tempuri.org/IUserService/CheckUserNameResponse")]
        bool CheckUserName(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/CheckUserName", ReplyAction="http://tempuri.org/IUserService/CheckUserNameResponse")]
        System.Threading.Tasks.Task<bool> CheckUserNameAsync(string userName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserServiceChannel : TestProject.UserServiceReference.IUserService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserServiceClient : System.ServiceModel.ClientBase<TestProject.UserServiceReference.IUserService>, TestProject.UserServiceReference.IUserService {
        
        public UserServiceClient() {
        }
        
        public UserServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ServiceLayer.UserServiceReference.UserData GetUserById(int id) {
            return base.Channel.GetUserById(id);
        }
        
        public System.Threading.Tasks.Task<ServiceLayer.UserServiceReference.UserData> GetUserByIdAsync(int id) {
            return base.Channel.GetUserByIdAsync(id);
        }
        
        public ServiceLayer.UserServiceReference.UserData GetUserByUserName(string userName) {
            return base.Channel.GetUserByUserName(userName);
        }
        
        public System.Threading.Tasks.Task<ServiceLayer.UserServiceReference.UserData> GetUserByUserNameAsync(string userName) {
            return base.Channel.GetUserByUserNameAsync(userName);
        }
        
        public int InsertUser(string userName, string email, string phone, string zipCode, string region, string password) {
            return base.Channel.InsertUser(userName, email, phone, zipCode, region, password);
        }
        
        public System.Threading.Tasks.Task<int> InsertUserAsync(string userName, string email, string phone, string zipCode, string region, string password) {
            return base.Channel.InsertUserAsync(userName, email, phone, zipCode, region, password);
        }
        
        public string TestString() {
            return base.Channel.TestString();
        }
        
        public System.Threading.Tasks.Task<string> TestStringAsync() {
            return base.Channel.TestStringAsync();
        }
        
        public bool CheckUserName(string userName) {
            return base.Channel.CheckUserName(userName);
        }
        
        public System.Threading.Tasks.Task<bool> CheckUserNameAsync(string userName) {
            return base.Channel.CheckUserNameAsync(userName);
        }
    }
}