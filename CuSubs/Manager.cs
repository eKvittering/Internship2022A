using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CuSubs
{
    public class Manager 
    {
        private readonly Context _context;

        public Manager (Context context)
        {
            _context = context;
        }
        public Manager()
        {
        }

        public async Task<List<Customers>> GetAllCustomer()
        {
            var c = _context.Customers.Count();
            var customers =  _context.Customers;
            if (c==0)
            {
                throw new Exception();
            }
            return await customers.ToListAsync();

        }
        public async Task<Customers> AddCustomer(Customers customers)
        {
            _context.Customers.Add(customers);
            await _context.SaveChangesAsync();
            return customers;
        }

        public async Task<Customers> DeleteCustomer(int id)
        {
            var result = await _context.Customers.FirstOrDefaultAsync(s => s.CustomerId == id);
            if (result != null)
            {
                var m = new Customers();
                _context.Customers.Remove(result);
                m.CustomerId = await _context.SaveChangesAsync();
                return m;
            }
            return null;
        }
        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
        public static void SetPropertyValue(object obj, string propName, object value)
        {
            obj.GetType().GetProperty(propName).SetValue(obj, value, null);
        }
        public static void CopyIfDifferent(Object target, Object source)
        {
            foreach (var prop in target.GetType().GetProperties())
            {
                var targetValue = GetPropValue(target, prop.Name);
                var sourceValue = GetPropValue(source, prop.Name);
                if (String.IsNullOrEmpty(Convert.ToString(targetValue)))
                {
                    SetPropertyValue(target, prop.Name, sourceValue);
                }
            }
        }

        public async Task<Customers> UpdateCustomer(Customers cus)
        {
            var result = await _context.Customers.AsNoTracking().FirstOrDefaultAsync(s => s.CustomerId == cus.CustomerId);
           
            if (result != null)
            {
                CopyIfDifferent(cus, result);
                var m = new Customers();
                _context.Update(cus);
                m.CustomerId = await _context.SaveChangesAsync();
                return m;
            }
            return null;
        }


        public async Task<List<Subscriptions>> GetAllSub()
        {
            var c = _context.Subscriptions.Count();
            var sub = _context.Subscriptions;
            if (c == 0)
            {
                throw new Exception();
            }
            return await sub.ToListAsync();

        }
        public async Task<Subscriptions> AddSub(Subscriptions sub)
        {
            _context.Subscriptions.Add(sub);
            await _context.SaveChangesAsync();
            return sub;
        }

        public async Task<Subscriptions> DeleteSub(int id)
        {
            var result = await _context.Subscriptions.FirstOrDefaultAsync(s => s.SubscriptionId == id);
            if (result != null)
            {
                var m = new Subscriptions();
                _context.Subscriptions.Remove(result);
                m.SubscriptionId = await _context.SaveChangesAsync();
                return m;
            }
            return null;
        }
        
        

        public async Task<Subscriptions> UpdateSub(Subscriptions cus)
        {
            var result = await _context.Subscriptions.AsNoTracking().FirstOrDefaultAsync(s => s.SubscriptionId == cus.SubscriptionId);

            if (result != null)
            {
                CopyIfDifferent(cus, result);
                var m = new Subscriptions();
                _context.Update(cus);
                m.SubscriptionId = await _context.SaveChangesAsync();
                return m;
            }
            return null;
        }

        


    }
}
