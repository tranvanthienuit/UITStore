using System;
using System.Collections.Generic;
using System.Text;
using UITStore.Models;
using UITStore.Services;

namespace UITStore.ViewModels
{
    public class SneakerVM
    {
        public List<Sneakers> GetSneaker()
        {
            SneakerModel result = SneakerService.ServiceClientInstance.GetSneaker().Result;
            if (result.success)
            {
                List<Sneakers> listSneaker = result.data;
                return listSneaker;
            }
            else
            {
                return null;
            }
        }
        public Sneakers GetSneakerById(Guid id)
        {
            ResponseUpdateSneaker result = SneakerService.ServiceClientInstance.GetSneakerById(id).Result;
            if (result.success)
            {
                Sneakers sneaker = result.data;
                return sneaker;
            }
            else
            {
                return null;
            }
        }
        public List<Sneakers> FilterSneaker(int Size,string Type, string Filter)
        {
            SneakerModel result = SneakerService.ServiceClientInstance.SneakerFilter(Size, Type, Filter).Result;
            if (result.success)
            {
                List<Sneakers> listSneaker = result.data;
                return listSneaker;
            }
            else
            {
                return null;
            }
        }
        public bool UpdateSneaker(Guid Id, string Name, string Size, int Stock, double Price, string Description, string Category, double SalePrice, string Image, double Discount, double Rating, DateTime CreateDate)
        {
            Sneakers sneakers = new Sneakers
            {
                id = Id, name = Name, size = Size, stock = Stock, price = Price, description = Description, category = Category, salePrice = SalePrice, image = Image,
                 discount = Discount, rating = Rating, createDate = CreateDate
            };
            ResponseUpdateSneaker result = SneakerService.ServiceClientInstance.UpdateSneaker(sneakers).Result;
            if (result.success)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
