using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentMangment.Models
{
    public class UnitOfWork : IDisposable
    {
        private StudentMangmentContext context = new StudentMangmentContext();
        private GenericRepository<Enrollment> departmentRepository;
        private GenericRepository<Course> courseRepository;

        public GenericRepository<Enrollment> DepartmentRepository
        {
            get
            {

                if (this.departmentRepository == null)
                {
                    this.departmentRepository = new GenericRepository<Enrollment>(context);
                }
                return departmentRepository;
            }
        }

        public GenericRepository<Course> CourseRepository
        {
            get
            {

                if (this.courseRepository == null)
                {
                    this.courseRepository = new GenericRepository<Course>(context);
                }
                return courseRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}