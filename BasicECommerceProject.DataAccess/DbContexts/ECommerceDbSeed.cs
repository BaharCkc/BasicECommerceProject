using BasicECommerceProject.Core.Constant;
using BasicECommerceProject.Core.Models.Common;
using BasicECommerceProject.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceProject.DataAccess.DbContexts
{
    public static class ECommerceDbSeed
    {
        private static void GetAndAddEnums<TEntity, TEnum>(this DbContext dbContext, bool create,
IDictionary<TEnum, int> ids) where TEntity : BaseEnum
        {
            foreach (TEnum e in Enum.GetValues(typeof(TEnum)))
            {
                var name = e.ToString();
                var query = dbContext.Set<TEntity>().SingleOrDefault(q => q.Name == name);
                if (query != null)
                {
                    ids.Add(e, query.Id);
                }
                else if (create)
                {
                    var memberInfo = typeof(TEnum).GetMember(name)[0];
                    var hasDisplayAttribute = Attribute.IsDefined(memberInfo, typeof(DisplayAttribute));
                    var displayAttribute =
                        hasDisplayAttribute ? memberInfo.GetCustomAttribute<DisplayAttribute>() : null;

                    if (displayAttribute?.Description != null)
                    {
                        var newEntity =
                            (TEntity)Activator.CreateInstance(typeof(TEntity), name, displayAttribute.Description);
                        newEntity.RecordDate = DateTime.Now;
                        var entity = dbContext.Set<TEntity>().Add(newEntity).Entity;
                        dbContext.SaveChanges();
                        ids.Add(e, entity.Id);
                    }
                    else
                    {
                        var newEntity = (TEntity)Activator.CreateInstance(typeof(TEntity), name);
                        var entity = dbContext.Set<TEntity>().Add(newEntity).Entity;
                        dbContext.SaveChanges();
                        ids.Add(e, entity.Id);
                    }
                }
            }
        }
        public static async void Initialize(IServiceProvider serviceProvider, bool create = false)
        {
            using var serviceScope = serviceProvider.CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetService<ECommerceDbContext>();
            dbContext.Database.Migrate();

            dbContext.GetAndAddEnums<Status, Constants.StatusEnum>(create, Constants.StatusEnumIds);

            if (!dbContext.Order.Any())
            {
                var assembly = typeof(ECommerceDbContext).GetTypeInfo().Assembly;

                var seedstream =
                    assembly.GetManifestResourceStream("BasicECommerceProject.DataAccess.Assets.Json.seed.json");
             var seed = new StreamReader(seedstream ?? throw new InvalidOperationException());
                var seedstreamjson = seed.ReadToEnd();
                var seedlist = JsonConvert.DeserializeObject<List<SeedJsonModel>>(seedstreamjson);

                foreach (var item in seedlist)
                {
                    var itemStatusName = $"_{item.Status.ToString()}";
                    var status = dbContext.Status.Where(b => b.Name == itemStatusName).FirstOrDefault();


                    if (status != null)
                    {
                        var order = dbContext.Order.Add(new Order
                        {
                            //Id = item.Id,
                            Amount = item.Amount,
                            OrderDate = item.OrderDate,
                            OrderNumber = item.OrderNumber,
                            OrderSource = item.OrderSource,
                            StatusId = status.Id,
                            IsDeleted = false,
                            RecordDate = DateTime.Now,

                        });
                        dbContext.SaveChanges();


                        foreach (var lines in item.LineInterviews)
                            dbContext.Line.Add(new Line
                            {
                                //Id = lines.Id,
                                Amount = lines.Amount,
                                OrderId = order.Entity.Id,
                                IsDeleted = false,
                                ProductName = lines.ProductName,
                                Quantity = lines.Quantity,
                                RecordDate = DateTime.Now
                            });

                        dbContext.Cargo.Add(new Cargo
                        {
                            //Id = item.CargoInterview.Id,
                            Name = item.CargoInterview.Name,
                            TrackingNumber = item.CargoInterview.TrackingNumber,
                            OrderId = order.Entity.Id,
                            IsDeleted = false,
                            RecordDate = DateTime.Now
                        });

                        dbContext.SaveChanges();
                    }
                    
                }
            }
        }
    }
}
