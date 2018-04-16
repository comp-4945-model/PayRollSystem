using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PayRoll.Models
{
    public class PayrollDbInitializer : DropCreateDatabaseAlways<PayrollDbContext>
    {
        protected override void Seed(PayrollDbContext context)
        {
            context.Positions.Add(new Position()
            {
                PositionId = "Web Developer",
                Rank = 1
            });

            context.Positions.Add(new Position()
            {
                PositionId = "Manager",
                Rank = 4
            });

            context.Positions.Add(new Position()
            {
                PositionId = "Human Resources",
                Rank = 7
            });

            context.Positions.Add(new Position()
            {
                PositionId = "Master",
                Rank = 100
            });
            context.Schedules.Add(new Schedule()
            {
                ShiftId = 1,
                StartTime = DateTime.Parse("2018-1-1 8:00:00 AM"),
                EndTime = DateTime.Parse("2018-1-1 4:00:00 PM"),
            });
			context.Schedules.Add(new Schedule()
			{
				ShiftId = 2,
				StartTime = DateTime.Parse("2018-4-17 8:00:00 AM"),
				EndTime = DateTime.Parse("2018-4-17 4:00:00 PM"),
			});
			context.Schedules.Add(new Schedule()
			{
				ShiftId = 3,
				StartTime = DateTime.Parse("2018-4-20 8:00:00 AM"),
				EndTime = DateTime.Parse("2018-4-20 4:00:00 PM"),
			});

			context.SaveChanges();

            context.Employees.Add(new Employee()
            {
                EmployeeId = "a00828729",
                Password = "1234567890",
                FName = "Davin",
                LName = "Deol",
                Address = "4652 Redex Blvd",
                Email = "davindeol@gmail.com",
                FullOrPartTime = "Part-Time",
                Seniority = 4,
                DepartmentType = "Executive",
                HourlyRate = 35.00m
            });

            context.Employees.Add(new Employee()
            {
                EmployeeId = "a00000000",
                Password = "password",
                FName = "Mas",
                LName = "Ter",
                Address = "34573 Ma Str.",
                Email = "master@master.com",
                FullOrPartTime = "Full-Time",
                Seniority = 10,
                DepartmentType = "Executive",
                HourlyRate = 75.00m
            });
            context.SaveChanges();
            context.Positions.Find("Manager").Employees.Add(context.Employees.Find("a00828729"));
            context.Positions.Find("Master").Employees.Add(context.Employees.Find("a00000000"));
            context.Schedules.Find(1).Employees.Add(context.Employees.Find("a00000000"));
            context.Schedules.Find(1).Employees.Add(context.Employees.Find("a00828729"));
			context.Schedules.Find(2).Employees.Add(context.Employees.Find("a00828729"));
			context.Schedules.Find(3).Employees.Add(context.Employees.Find("a00828729"));
			context.SaveChanges();

            //TypeOfTimeOff toto = context.TypesOfTimeOff.Where(s => s.Type == "Personal Reasons").FirstOrDefault();

            Employee e = new Employee()
            {
                EmployeeId = "a00828730",
                Password = "1020304050",
                FName = "Andra",
                LName = "Avram",
                Address = "Pinetree Way",
                Email = "vpnprez1@hotmail.com",
                FullOrPartTime = "Full-Time",
                Seniority = 4,
                DepartmentType = "Executive",
                HourlyRate = 35.00m,
                AwardedVacation = 15
            };


            e.Attendances.Add(new Attendance()
            {
                AttendanceId = 1,
                SignInTime = DateTime.Parse("2018-1-1 8:00:00 AM"),
                SignOutTime = DateTime.Parse("2018-1-1 8:00:00 PM"),

            });

            e.Attendances.Add(new Attendance()
            {
                AttendanceId = 2,
                SignInTime = DateTime.Parse("2018-2-1 8:00:00 AM"),
                SignOutTime = DateTime.Parse("2018-2-1 6:00:00 PM"),

            });

            context.Employees.Add(e);
            context.SaveChanges();
            context.Positions.Find("Human Resources").Employees.Add(context.Employees.Find("a00828730"));
            context.Schedules.Find(1).Employees.Add(context.Employees.Find("a00828730"));
			TimeOffRequest timeOffRequest = new TimeOffRequest()
			{
				StartDate = DateTime.Now,
				EndDate = DateTime.Now,
				Reason = "sample"
			};
			Employee employee = new Employee()
			{
				EmployeeId = "10",
				Password = "5AMP13PA55W0RD",
				FName = "Sam",
				LName = "Ple",
				FullOrPartTime = "Full-Time",
				Seniority = 1,
				DepartmentType = "Production",
				HourlyRate = 25
			};
			employee.TimeOffRequests.Add(timeOffRequest);
			context.Employees.Add(employee);
			context.SaveChanges();
			employee = context.Employees.Find("10");
			context.TimeOffRequests.RemoveRange(context.TimeOffRequests.Where(t => t.Employee.EmployeeId == employee.EmployeeId));
			context.Employees.Remove(employee);
			context.SaveChanges();
			var x = context.Employees.OrderBy(em => em.FName);
			var y = context.Employees.OrderByDescending(em => em.Email);
			TimeOffRequest a = new TimeOffRequest()
			{
				StartDate = DateTime.Now,
				EndDate = DateTime.Now,
				Reason = "time off A",
				Type = "Vacation"
			};
			TimeOffRequest b = new TimeOffRequest()
			{
				StartDate = DateTime.Now,
				EndDate = DateTime.Now,
				Reason = "time off B",
				Type = "Appointment"
			};
			TimeOffRequest c = new TimeOffRequest()
			{
				StartDate = DateTime.Now,
				EndDate = DateTime.Now,
				Reason = "time off C",
				Type = "Vacation"
			};
			TimeOffRequest d = new TimeOffRequest()
			{
				StartDate = DateTime.Now,
				EndDate = DateTime.Now,
				Reason = "time off D",
				Type = "Personal Emergency"
			};
			employee = context.Employees.Find("a00828730");
			employee.TimeOffRequests.Add(a);employee.TimeOffRequests.Add(b);employee.TimeOffRequests.Add(c);employee.TimeOffRequests.Add(d);
			context.Entry(employee).State = EntityState.Modified;
			context.SaveChanges();
			var z = context.TimeOffRequests.GroupBy(t => t.Type).Select(g => new { name = g.Key, count = g.Count() });
			var f = context.TimeOffRequests.Include(t => t.Employee).Where(t => t.Employee.FName == employee.FName).ToList();
			base.Seed(context);
        }
    }
}