using TestLanding.Domain;

namespace TestLanding.Services.Data;

public class TestData
{
    public static ICollection<Department> Departments { get; } = new List<Department>()
    {
        new() { Name = "Logistic" },
        new() { Name = "Sales" },
        new() { Name = "Development" },
        new() { Name = "Research" },
        new() { Name = "HR" },
        new() { Name = "Support"},
    };

    public static ICollection<Employee> Employees { get; } = new List<Employee>()
    {
        new()
        {
            Department = Departments.First(d => d.Id == 0),
            LastName="Иванов",
            FirstName = "Иван",
            Patronymic = "Иванович",
            DateOfEmployment = new DateTime(2010, 6, 13),
            Salary = 15000,
        },
        new()
        {
            Department = Departments.First(d => d.Id == 1),
            LastName = "Иванов",
            FirstName = "Петр",
            Patronymic = "Сергеевич",
            DateOfEmployment = new DateTime(2012, 8, 15),
            Salary = 20000,
        },
        new()
        {
            Department = Departments.First(d => d.Id == 2),
            LastName = "Сидоров",
            FirstName = "Максим",
            Patronymic = "Анатольевич",
            DateOfEmployment = new DateTime(2014, 9, 11),
            Salary = 24000,
        },
        new()
        {
            Department = Departments.First(d => d.Id == 3),
            LastName = "Выготский",
            FirstName = "Лев",
            Patronymic = "Семёнович",
            DateOfEmployment = new DateTime(2015, 12, 9),
            Salary = 30000,
        },
        new()
        {
            Department = Departments.First(d => d.Id == 4),
            LastName = "Вернадский",
            FirstName = "Антон",
            Patronymic = "Павлович",
            DateOfEmployment = new DateTime(2018, 10, 22),
            Salary = 14000,
        },
        new()
        {
            Department = Departments.First(d => d.Id == 5),
            LastName = "Кюри",
            FirstName = "Мария",
            Patronymic = "Владимировна",
            DateOfEmployment = new DateTime(2011, 3, 30),
            Salary = 45000,
        },
        new()
        {
            Department = Departments.First(d => d.Id == 0),
            LastName = "Гордеева",
            FirstName = "Екатерина",
            Patronymic = "Владимировна",
            DateOfEmployment = new DateTime(2022, 2, 24),
            Salary = 50000,
        },
        new()
        {
            Department = Departments.First(d => d.Id == 1),
            LastName = "Циолковский",
            FirstName = "Константин",
            Patronymic = "Эдуардович",
            DateOfEmployment = new DateTime(2015, 5, 1),
            Salary = 55000,
        },
        new()
        {
            Department = Departments.First(d => d.Id == 2),
            LastName = "Кнорозов",
            FirstName = "Юрий",
            Patronymic = "Валентинович",
            DateOfEmployment = new DateTime(2008, 4, 2),
            Salary = 35000,
        },
        new()
        {
            Department = Departments.First(d => d.Id == 3),
            LastName = "Цветаева",
            FirstName = "Марина",
            Patronymic = "Ивановна",
            DateOfEmployment = new DateTime(2021, 3, 18),
            Salary = 9000,
        },
        new()
        {
            Department = Departments.First(d => d.Id == 4),
            LastName = "Айвазовский",
            FirstName = "Иван",
            Patronymic = "Константинович",
            DateOfEmployment = new DateTime(2020, 2, 10),
            Salary = 30000,
        },
        new()
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
