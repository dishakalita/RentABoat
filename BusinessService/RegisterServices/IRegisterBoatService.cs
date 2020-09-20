using System;
using System.Collections.Generic;
using System.Text;
using ViewModels;

namespace BusinessService.RegisterServices
{
    public interface IRegisterBoatService
    {
        int RegisterBoat(string boatName, decimal hourlyRate);
    }
}
