﻿using Unit_Of_Work.DMO;

namespace Unit_Of_Work.Repository
{
	public interface IRepository<T>
	{
		bool Add(T model);
        void Add(Autorization autorization);
    }
}
