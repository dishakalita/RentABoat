using System;
using System.Collections.Generic;
using System.Text;
using ViewModels;

namespace BusinessService.RentServices
{
    public interface IRentBoatService
    {
        List<BoatModel> GetBoats();
        void RentBoatToCustomer(int boatId,string customerName,long contactNo);
    }
}
