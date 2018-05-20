using EF_DBContext.Models;
using Services.Contract;
using Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyStore.Controllers
{
    public class StoreController : ApiController
    {
        private IStoreService StoreService = null;

        public StoreController()
        {
            StoreService = new StoreService();
        }

        [Route("api/GetAllStore")]
        public HttpResponseMessage GetAllStores() 
        {
            return Request.CreateResponse(HttpStatusCode.Accepted, StoreService.GetAllStores());            
        }

        [Route("api/AddStores")]
        public HttpResponseMessage AddStores(MstStore store)
        {
            if (store != null)
                return Request.CreateResponse(HttpStatusCode.Accepted, StoreService.AddStore(store));
            else
                return Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, "Model is null.");
        }

        [Route("api/UpdateStores")]
        public HttpResponseMessage UpdateStores(MstStore store)
        {
            if (store != null)
                return Request.CreateResponse(HttpStatusCode.Accepted, StoreService.UpdateStore(store));
            else
                return Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, "Model is null.");
        }

        [Route("api/DeleteStores")]
        public HttpResponseMessage DeleteStores(int storeId)
        {
            if (storeId > 0)
                return Request.CreateResponse(HttpStatusCode.Accepted, StoreService.DeleteStore(storeId));
            else
                return Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, "Store Id is zero.");
        }
    }
}
