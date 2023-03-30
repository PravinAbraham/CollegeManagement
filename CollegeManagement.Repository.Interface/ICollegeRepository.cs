namespace CollegeManagement.Repository.Interface
{
    public interface ICollegeRepository
    {
        public List<College> GetAll();
        public List<College> GetById(int Id);
        public List<College> GetBySelectedRow(string All);
        public College Create(College college);
        public List<College> Update(int Id, College college);
        public string UpdateName(int Id, College college);
        public string Delete(int id);
        public List<College> Offset(int limit, int offset);
        public List<College> Omit(int omit);
        public List<College> Pagination(int page, int pageSize);
        public List<College> Filter(string Search, int page, int pageSize);
        public List<College> Cursor(int page, int pageSize);
        public List<College> Info(int page, int pageSize);
        public PageInfo pageInfos();
    }
}
