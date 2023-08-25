using System;
using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Model : Entity<Guid>
	{
		public Guid BrandId { get; set; }
		public Guid FuelId { get; set; }
		public Guid TransmissionId { get; set; }
		public string Name { get; set; }
		public decimal DailyPrice { get; set; }
		public string ImageUrl { get; set; }

		public virtual Brand? Brand { get; set; }
		public virtual Fuel? Fuel { get; set; }
		public virtual Transmission? Transmission { get; set; }

		public virtual ICollection<Car>? Cars { get; set; }

		public Model()
		{
			Cars = new HashSet<Car>();
		}

		public Model(Guid id,Guid brandId,Guid fueldId,Guid transmissionId,string name,decimal dailyPrice,string imageUrl):this() 
		{
			Id = id;
			BrandId = brandId;
			FuelId = fueldId;
			TransmissionId = transmissionId;
			Name = name;
			DailyPrice = dailyPrice;
			ImageUrl = imageUrl;
		}
	}
}

