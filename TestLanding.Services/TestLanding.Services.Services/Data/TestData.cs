using TestLanding.Domain;

namespace TestLanding.Services.Data;

public class TestData
{
    static TestData()
    {
        var departments = new Department[]
        {
            new () { Name = "Logistic", Order = 0 },
            new () { Name = "Sales", Order = 1 },
            new () { Name = "Development", Order = 2 },
            new () { Name = "Research", Order = 3 },
            new () { Name = "HR", Order = 4 },
            new () { Name = "Support", Order = 5 },
        };

        var employees = new Employee[]
        {
            new Employee
            {
                LastName="Иванов",
                FirstName = "Иван",
                Patronymic = "Иванович",
                DateOfEmployment = new DateTime(2010, 6, 13),
                Salary = 15000,
                Department = departments[0],
                DateOfBirth = new DateTime(1989, 6, 11),                
            },
            new Employee
            {
                LastName = "Иванов",
                FirstName = "Петр",
                Patronymic = "Сергеевич",
                DateOfEmployment = new DateTime(2012, 8, 15),
                Salary = 20000,
                Department = departments[1],
                DateOfBirth = new DateTime(1994, 7, 13),
            },
            new Employee
            {
                LastName = "Сидоров",
                FirstName = "Максим",
                Patronymic = "Анатольевич",
                DateOfEmployment = new DateTime(2014, 9, 11),
                Salary = 24000,
                Department = departments[2],
                DateOfBirth = new DateTime(2000, 8, 1),
            },
            new Employee
            {
                LastName = "Выготский",
                FirstName = "Лев",
                Patronymic = "Семёнович",
                DateOfEmployment = new DateTime(2015, 12, 9),
                Salary = 30000,
                Department = departments[3],
                DateOfBirth = new DateTime(1979, 9, 19),
            },
            new Employee
            {
                LastName = "Вернадский",
                FirstName = "Антон",
                Patronymic = "Павлович",
                DateOfEmployment = new DateTime(2018, 10, 22),
                Salary = 14000,
                Department = departments[4],
                DateOfBirth = new DateTime(1995, 10, 30),
            },
            new Employee
            {
                LastName = "Кюри",
                FirstName = "Мария",
                Patronymic = "Владимировна",
                DateOfEmployment = new DateTime(2011, 3, 30),
                Salary = 45000,
                Department = departments[5],
                DateOfBirth = new DateTime(1980, 11, 24),
            },
            new Employee
            {
                LastName = "Гордеева",
                FirstName = "Екатерина",
                Patronymic = "Владимировна",
                DateOfEmployment = new DateTime(2022, 2, 24),
                Salary = 50000,
                Department = departments[0],
                DateOfBirth = new DateTime(1984, 12, 10),
            },
            new Employee
            {
                LastName = "Циолковский",
                FirstName = "Константин",
                Patronymic = "Эдуардович",
                DateOfEmployment = new DateTime(2015, 5, 1),
                Salary = 55000,
                Department = departments[1],
                DateOfBirth = new DateTime(1970, 1, 11),
            },
            new Employee
            {
                LastName = "Кнорозов",
                FirstName = "Юрий",
                Patronymic = "Валентинович",
                DateOfEmployment = new DateTime(2008, 4, 2),
                Salary = 35000,
                Department = departments[2],
                DateOfBirth = new DateTime(1979, 2, 14),
            },
            new Employee
            {
                LastName = "Цветаева",
                FirstName = "Марина",
                Patronymic = "Ивановна",
                DateOfEmployment = new DateTime(2021, 3, 18),
                Salary = 9000,
                Department = departments[3],
                DateOfBirth = new DateTime(1989, 3, 8),
            },
            new Employee
            {
                LastName = "Айвазовский",
                FirstName = "Иван",
                Patronymic = "Константинович",
                DateOfEmployment = new DateTime(2020, 2, 10),
                Salary = 30000,
                Department = departments[4],
                DateOfBirth = new DateTime(1997, 4, 12),
            },
            new Employee
            {
                LastName = "Кулибин",
                FirstName = "Иван",
                Patronymic = "Петрович",
                DateOfEmployment = new DateTime(2019, 1, 20),
                Salary = 25000,
                Department = departments[5],
                DateOfBirth = new DateTime(1991, 5, 1),
            },
        };

        Departments = departments;
        Employees = employees;
    }

    public static ICollection<Department> Departments { get; }

    public static ICollection<Employee> Employees { get; }
    
}
