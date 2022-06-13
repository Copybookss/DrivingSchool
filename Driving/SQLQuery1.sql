SELECT    dbo.Curses.id AS CursID, dbo.Curses.Name AS CursName, dbo.Instructors.Name AS Instructor, dbo.Students.Name AS Student, dbo.Instructors.Car AS CarName, dbo.Curses.Salary AS CursSalary, 
                      dbo.Curses.StartDate AS SDate, dbo.Curses.EndDate AS EDate
FROM         dbo.Curses INNER JOIN
                      dbo.Instructors ON dbo.Curses.Name = dbo.Instructors.Name INNER JOIN
                      dbo.Students ON dbo.Curses.id = dbo.Students.Name