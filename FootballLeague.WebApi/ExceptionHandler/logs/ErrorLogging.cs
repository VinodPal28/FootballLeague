using FootballLeague.Data.DomainContext;
using FootballLeague.EntityFramework.Entities;
using FootballLeague.Resources.Resources;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace FootballLeague.WebApi.ExceptionHandler.logs
{
    public class ErrorLogging
    {
        FootballLeagueDomainContext context = new FootballLeagueDomainContext();

        public void InsertErrorLog(logResource logger)
        {
            try
            {
                var entity = new log
                {
                    RequestMethod = logger.RequestMethod,
                    RequestUri = logger.RequestUri,
                    CreatedDate = logger.CreatedDate,
                    Message = logger.Message
                };
                context.Add(entity);
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}