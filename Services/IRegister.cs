using System;
using Registermvc.Models;

namespace Registermvc.Services
{
    public interface IRegister
    {
    //  int  RegisterNewUser (RegisterViewModel model); 
    Tuple<Register,int>  RegisterNewUser(RegisterViewModel model);
     
    }
}