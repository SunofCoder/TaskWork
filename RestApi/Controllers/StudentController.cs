using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;



namespace RestApi.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Models.Student> StudentList = new List<Models.Student>
     {
         new Models.Student
         {
             Id = 1,
             StudentName = "Ali",
             StudentLastName = "ASLAN",
             AssignmentWeek = 1,
             Result = 100,
         },new Models.Student
         {
             Id = 2,
             StudentName = "Deniz",
             StudentLastName = "Denizer",
             AssignmentWeek = 1,
             Result = 90,
         },
         new Models.Student
         {
             Id = 3,
             StudentName = "Selen",
             StudentLastName = "Sel",
             AssignmentWeek = 1,
             Result = 80,
         },
         };
        [HttpGet]

        public IActionResult GetAll()
        {
            return Ok(StudentList);
        }

        [HttpGet("assignmentWeek")]

    
    public IActionResult GetAll(int assignmentWeek)
    {
        var homework = StudentList.Where(a => a.AssignmentWeek == assignmentWeek).ToList();
        if (homework.Count < 1)
        {
            return BadRequest();
        }
        return Ok(homework);
    }

    [HttpGet("studentDetails")]

    public IActionResult studentDetails(string firstName, string lastName)
    {
        var student = StudentList.Where(a => a.StudentName == firstName && a.StudentLastName == lastName).ToList();

        if (student.Count < 1)
        {
            return NotFound();
        }
        return Ok(student);
    }
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var studentId = StudentList.Find(a => a.Id == id);

            if (studentId == null)
            {
                return NotFound();
            }
            StudentList.Remove(studentId);
            return Ok();
        }
        [HttpPatch("/Homeworks/{id}")]

        public IActionResult updateStudentResult(int id, [FromBody] float reviewedResult)
        {
            var homeworkResult = StudentList.Find(a => a.Id == id);
            if (homeworkResult == null)
            {
                return NotFound();
            }
            homeworkResult.Result = reviewedResult;
            return Ok();
        }

        [HttpPost]

        public void Post([FromBody] Models.Student student)
        {

            StudentList.Add(student);
        }

        [HttpPut]

        public void Put([FromBody] Models.Student student)
        {

            StudentList.Add(student);
        }
    }
}






