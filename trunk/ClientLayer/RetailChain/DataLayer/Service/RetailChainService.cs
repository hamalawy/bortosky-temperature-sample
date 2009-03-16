///////////////////////////////////////////////////////////
//  RetailChainService.cs
//  Implementation of the Class RetailChainService
//  Generated by Enterprise Architect
//  Created on:      16-Mar-2009 2:16:15 PM
//  Original author: Gary
///////////////////////////////////////////////////////////


using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Bortosky.Samples.RetailChain.Client.Data;

namespace Bortosky.Samples.RetailChain.Client.Service
{
    [ServiceContract(Namespace = "Bortosky.Samples.RetailChain.Client.Service")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class RetailChainService
    {
        IRetailerService retailerSvc;

        public RetailChainService()
        {
            this.retailerSvc = new XmlRetailerService();
        }

        [OperationContract]
        public IEnumerable<Store> GetStores()
        {
            return this.retailerSvc.GetStores();
        }

        /// 
        /// <param name="storeId"></param>
        [OperationContract]
        public Store GetStore(string storeId)
        {
            return this.retailerSvc.GetStore(storeId);
        }

        /// 
        /// <param name="storeId"></param>
        /// <param name="week"></param>
        [OperationContract]
        public IEnumerable<WeeklySale> GetWeeklySales(string storeId, string week)
        {
            return this.retailerSvc.GetWeeklySales(storeId, week);
        }

    }//end RetailChainService

}//end namespace Service