using Microsoft.EntityFrameworkCore;
using Registermvc.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Registermvc.Services
{
    public class Registration : IRegister
    {

        private readonly  RegisterdbContext  _options;

        public Registration( RegisterdbContext options)
        {
            _options = options; 
        }

        public Tuple<Register,int>  RegisterNewUser(RegisterViewModel model)
        {

           var GrossIncome= model.Salary*12;
           var tax = Tax ( model.Salary, 25);
           decimal annualTax=tax*12;

           decimal netSalary= GrossIncome-annualTax;

           var entry = new  Register
           {
                GrossIncome=GrossIncome,
                NetIncome=netSalary,
                Salary=model.Salary,
                FirstName=model.FirstName,
                LastName=model.LastName,
                Email=model.Email,
                PhoneNumber = model.PhoneNumber,
           };

            _options.Add(entry);
           int success= _options.SaveChanges(); 
           return new Tuple<Register,int>(entry,success);
            

        }

        private decimal Tax(decimal SalaryAmount , int Percentage)
        {
            decimal tax= (Percentage/100) *SalaryAmount;
            return tax;       
        }

    }
}