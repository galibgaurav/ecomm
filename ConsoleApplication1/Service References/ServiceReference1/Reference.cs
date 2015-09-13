﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApplication1.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PurchaseItem", Namespace="http://schemas.datacontract.org/2004/07/eCommservices")]
    [System.SerializableAttribute()]
    public partial class PurchaseItem : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IAccountManagement")]
    public interface IAccountManagement {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountManagement/DoWork", ReplyAction="http://tempuri.org/IAccountManagement/DoWorkResponse")]
        void DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountManagement/GetProductList", ReplyAction="http://tempuri.org/IAccountManagement/GetProductListResponse")]
        string GetProductList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountManagement/GetPurchaseList", ReplyAction="http://tempuri.org/IAccountManagement/GetPurchaseListResponse")]
        string GetPurchaseList(ConsoleApplication1.ServiceReference1.PurchaseItem[] purchaseLst);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountManagement/GetProductDetails", ReplyAction="http://tempuri.org/IAccountManagement/GetProductDetailsResponse")]
        string GetProductDetails(string ProductID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAccountManagement/GetProductForACategory", ReplyAction="http://tempuri.org/IAccountManagement/GetProductForACategoryResponse")]
        string GetProductForACategory(string productTypeID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAccountManagementChannel : ConsoleApplication1.ServiceReference1.IAccountManagement, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AccountManagementClient : System.ServiceModel.ClientBase<ConsoleApplication1.ServiceReference1.IAccountManagement>, ConsoleApplication1.ServiceReference1.IAccountManagement {
        
        public AccountManagementClient() {
        }
        
        public AccountManagementClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AccountManagementClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AccountManagementClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AccountManagementClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DoWork() {
            base.Channel.DoWork();
        }
        
        public string GetProductList() {
            return base.Channel.GetProductList();
        }
        
        public string GetPurchaseList(ConsoleApplication1.ServiceReference1.PurchaseItem[] purchaseLst) {
            return base.Channel.GetPurchaseList(purchaseLst);
        }
        
        public string GetProductDetails(string ProductID) {
            return base.Channel.GetProductDetails(ProductID);
        }
        
        public string GetProductForACategory(string productTypeID) {
            return base.Channel.GetProductForACategory(productTypeID);
        }
    }
}
