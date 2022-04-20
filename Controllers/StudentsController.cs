#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly FinalProjectDBContext _context;

        public StudentsController(FinalProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetStudent(int id)
        {
            var student = await _context.Students.Include(s => s.Seat).FirstOrDefaultAsync(s => s.StudentId == id);

            Response res = new Response();

            if (student == null)
            {
                res.StatusCode =404;
                res.StatusDescription = "Student is not found";
                return res;
            }
            res.StatusCode = 200;
            res.StatusDescription = "Student found";
            res.Data = student;
            return res;
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteStudent(int id)
        {
            var student = await _context.Students.Include(s => s.Seat).DefaultIfEmpty().FirstOrDefaultAsync(s => s.StudentId == id);
 
            Response res = new Response();
            if (student == null)
            {
                res.StatusCode = 404;
                res.StatusDescription = "Student not found";
                return res;
            }
            var seat = await _context.Seats.FirstOrDefaultAsync(s => s.SeatId == student.Seat.SeatId);
            _context.Students.Remove(student);
            

            if (seat!=null) 
            {
                // if seat exists, we change its Occupied status to False
                seat.Occupied = false;
                _context.Seats.Update(seat);
            }

            await _context.SaveChangesAsync();

            res.StatusCode = 200;
            res.StatusDescription = "Successfully deleted student and occupied seat changed to false";
            return res;
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }
    }
}
