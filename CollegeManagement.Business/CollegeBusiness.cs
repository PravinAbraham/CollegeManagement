using CollegeManagement.Business.Interface;
using CollegeManagement.Repository.Interface;

namespace CollegeManagement.Business
{
    public class CollegeBusiness : ICollegeBusiness
    {
        private readonly ICollegeRepository _collegeRepository;
        public CollegeBusiness(ICollegeRepository collegeRepository)
        {
            _collegeRepository = collegeRepository;
        }


        public List<College> GetAll()
        {
            List<College> list = new List<College>();
            
            return _collegeRepository.GetAll();
        }


        public List<College> GetById(int Id)
        {
            return _collegeRepository.GetById(Id);
        }

        public List<College> GetBySelectedRow(string Search)
        {
            return _collegeRepository.GetBySelectedRow(Search);
        }


        public College Create(College college)
        {
            return _collegeRepository.Create(college);
        }


        public List<College> Update(int Id, College college)
        {
            return _collegeRepository.Update(Id, college);
        }


        public string UpdateName(int Id, College college)
        {
            return _collegeRepository.UpdateName(Id, college);
        }


        public string Delete(int Id)
        {
            return _collegeRepository.Delete(Id);
        }



        public List<College> Offset(int limit, int offset)
        {
            return _collegeRepository.Offset(limit, offset);
        }




        public List<College> Omit(int omit)
        {
            return _collegeRepository.Omit(omit);
        }



        public List<College> Pagination(int page, int pageSize)
        {
            return _collegeRepository.Pagination(page, pageSize);
        }

        public List<College> Filter(string Search, int page, int pageSize)
        {
            return _collegeRepository.Filter(Search, page, pageSize);
        }
        public List<College> Cursor(int page, int pageSize)
        {
            return _collegeRepository.Cursor(page, pageSize);
        }
        public List<College> Info(int page, int pageSize)
        {
            return _collegeRepository.Info(page,pageSize);
        }
        public PageInfo pageInfos()
        {
            return _collegeRepository.pageInfos();
        }
    }
        
}
