using TestLanding.Domain;

namespace TestLanding.Services.Data;

public class TestData
{
    public static IEnumerable<Department> Departments { get; } = new[]
    {
        new Department { Id = 1, Name = "Logistic", Order = 0 },
        new Department { Id = 2, Name = "Sales", Order = 1 },
        new Department { Id = 3, Name = "Development", Order = 2 },
        new Department { Id = 4, Name = "Research", Order = 3 },
        new Department { Id = 5, Name = "HR", Order = 4 },
        new Department { Id = 6, Name = "Support", Order = 5 },
    };

    public static IEnumerable<Employee> Employees { get; } = new[]
    {
        new Employee 
        {
            Department = Departments.First(d => d.Id == 0),
            LastName="Иванов",
            FirstName = "Иван",
            Patronymic = "Иванович",
            DateOfEmployment = new DateTime(2010, 6, 13),
            Salary = 15000,
        },
        new Employee
        {
            Department = Departments.First(d => d.Id == 1),
            LastName = "Иванов",
            FirstName = "Петр",
            Patronymic = "Сергеевич",
            DateOfEmployment = new DateTime(2012, 8, 15),
            Salary = 20000,
        },
        new Employee
        {
            Department = Departments.First(d => d.Id == 2),
            LastName = "Сидоров",
            FirstName = "Максим",
            Patronymic = "Анатольевич",
            DateOfEmployment = new DateTime(2014, 9, 11),
            Salary = 24000,
        },
        new Employee
        {
            Department = Departments.First(d => d.Id == 3),
            LastName = "Выготский",
            FirstName = "Лев",
            Patronymic = "Семёнович",
            DateOfEmployment = new DateTime(2015, 12, 9),
            Salary = 30000,
        },
        new Employee
        {
            Department = Departments.First(d => d.Id == 4),
            LastName = "Вернадский",
            FirstName = "Антон",
            Patronymic = "Павлович",
            DateOfEmployment = new DateTime(2018, 10, 22),
            Salary = 14000,
        },
        new Employee
        {
            Department = Departments.First(d => d.Id == 5),
            LastName = "Кюри",
            FirstName = "Мария",
            Patronymic = "Владимировна",
            DateOfEmployment = new DateTime(2011, 3, 30),
            Salary = 45000,
        },
        new Employee
        {
            Department = Departments.First(d => d.Id == 0),
            LastName = "Гордеева",
            FirstName = "Екатерина",
            Patronymic = "Владимировна",
            DateOfEmployment = new DateTime(2022, 2, 24),
            Salary = 50000,
        },
        new Employee
        {
            Department = Departments.First(d => d.Id == 1),
            LastName = "Циолковский",
            FirstName = "Константин",
            Patronymic = "Эдуардович",
            DateOfEmployment = new DateTime(2015, 5, 1),
            Salary = 55000,
        },
        new Employee
        {
            Department = Departments.First(d => d.Id == 2),
            LastName = "Кнорозов",
            FirstName = "Юрий",
            Patronymic = "Валентинович",
            DateOfEmployment = new DateTime(2008, 4, 2),
            Salary = 35000,
        },
        new Employee
        {
            Department = Departments.First(d => d.Id == 3),
            LastName = "Цветаева",
            FirstName = "Марина",
            Patronymic = "Ивановна",
            DateOfEmployment = new DateTime(2021, 3, 18),
            Salary = 9000,
        },
        new Employee
        {
            Department = Departments.First(d => d.Id == 4),
            LastName = "Айвазовский",
            FirstName = "Иван",
            Patronymic = "Константинович",
            DateOfEmployment = new DateTime(2020, 2, 10),
            Salary = 30000,
        },
        new Employee
        {
            Department = Departments.First(d => d.Id == 5),
            LastName = "Кулибин",
            FirstName = "Иван",
            Patronymic = "Петрович",
            DateOfEmployment = new DateTime(2019, 1, 20),
            Salary = 25000,
        },
    };
}
