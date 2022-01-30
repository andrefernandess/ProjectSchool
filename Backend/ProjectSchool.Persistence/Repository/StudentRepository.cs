using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectSchool.Domain.Models;
using ProjectSchool.Persistence.Context;
using ProjectSchool.Persistence.Interfaces;

namespace ProjectSchool.Persistence.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;

        public StudentRepository(DataContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }


        public void Add(Student student)
        {
            _context.Add(student);
        }

        public void Update(Student student)
        {
            _context.Update(student);
        }

        public void Delete(Student student)
        {
            _context.Remove(student);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            IQueryable<Student> query = _context.Students;

            query = query.OrderBy(s => s.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Student> GetById(int Id)
        {
            IQueryable<Student> query = _context.Students;

            query = query.Where(s => s.Id == Id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Student> GetByRa(string ra)
        {
            IQueryable<Student> query = _context.Students;

            query = query.Where(s => s.Ra == ra);

            return await query.FirstOrDefaultAsync();
        }
    }
}