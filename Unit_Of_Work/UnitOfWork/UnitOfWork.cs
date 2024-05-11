using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Unit_Of_Work.DMO;
using Unit_Of_Work.Repository;

namespace Unit_Of_Work.UnitOfWork
{
	public class UnitOfWork : IDisposable
	{

		AuthContext _authcontext;
		public IRepository<Authentication> _authRepository;

        public object ModelState { get; private set; }

        public UnitOfWork(IRepository<Authentication> repository,AuthContext context)
		{
			_authcontext= context;
			_authRepository= repository;
		}

		public void Save()
		{
			try
			{
				using (var transaction =  _authcontext.Database.BeginTransaction())
				{

					// hata yoksa ise, işlem veri tabanına kaydedilsin.
					if (_authrepository==!null)
						{
							object value = _authcontext.Add(transaction);
							_authcontext.SaveChanges();
							return;

						}
					else
					{
                        //hata alındı işlemler geri alınıyor 
                        transaction.Rollback();
                    }
                    
                    
                }

			}catch (Exception ex)
			{

			}

		}

        public void Dispose()
		{
			// veri tabanını bellekten düşür
			_authcontext.Dispose();

			// GC : Garbage Collection
			// Gel Bu nesneyi bellekten sil
			GC.SuppressFinalize(this);


		}
	}
}
