using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_DBContext;
using EF_DBContext.Unit;
using EF_DBContext.Models;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //var context = new StoreContext();

            //var name = context.Store.FirstOrDefault().Name;
            //Console.WriteLine(name);
            //Console.ReadLine();

            //UnitOfWork uow = new UnitOfWork(new StoreContext());
            ////uow.StoreRepository.Add(new Store() { Name = "IT" });
            //uow.Complete();
            //var stores = uow.StoreRepository.GetStoreWithPaging(1, 10);
            //foreach(var store in stores)
            //{
            //    Console.WriteLine(store.Name);
            //}
            //Console.ReadLine();
        }
    }
}
