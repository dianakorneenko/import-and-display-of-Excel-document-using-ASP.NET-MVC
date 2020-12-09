using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Task2WebApplication.Models;

using Task2WebApplication.Concrete;
using System.Globalization;

namespace Task2WebApplication.Controllers
{
    public class HomeController : Controller
    {
        //основной метод, просто возвращает представление
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Import(HttpPostedFileBase fileExcel)
        {
            //указываем, если у нас состояние модели не валидное, то отправляе пользователя на главную стр сайта
            if (ModelState.IsValid)
            {
                // Открываем книгу
                using (var workbook = new XLWorkbook(fileExcel.InputStream))
                {

                    // Берем в ней первый лист
                    var worksheet = workbook.Worksheet(1);
                    using (MyDbContext db = new MyDbContext())
                    {
                        //в массиве rows я указываю строку названия класса, а дальше строки двузначных группы аккаунтов
                        int[] rows1 = new int[] { 9, 21, 28, 33, 44, 51, 63, 77, 81 };
                        AddClassToDB(db, worksheet, rows1);

                        int[] rows2 = new int[] { 83, 89, 115, 124, 151, 160, 168, 184 };
                        AddClassToDB(db, worksheet, rows2);

                        int[] rows3 = new int[] { 186, 196, 225, 237, 255, 266, 268 };
                        AddClassToDB(db, worksheet, rows3);

                        int[] rows4 = new int[] { 270, 274, 284, 288, 295 };
                        AddClassToDB(db, worksheet, rows4);

                        int[] rows5 = new int[] { 297, 301, 303, 307, 322, 324, 327 };
                        AddClassToDB(db, worksheet, rows5);

                        int[] rows6 = new int[] { 329, 331, 356, 360, 366, 374, 383, 396, 421, 432, 438 };
                        AddClassToDB(db, worksheet, rows6);

                        int[] rows7 = new int[] { 440, 451 };
                        AddClassToDB(db, worksheet, rows7);

                        int[] rows8 = new int[] { 453, 478, 491, 501, 508, 513, 515 };
                        AddClassToDB(db, worksheet, rows8);

                        int[] rows9 = new int[] { 517, 552, 562, 577, 615, 620, 624 };
                        AddClassToDB(db, worksheet, rows9);

                        //сохраняем данные в БД
                        db.SaveChanges();


                    }
                }
            }
            //отправляе пользователя на главную стр сайта
            return RedirectToAction("Index");
        }

        //метод для добвление класса в БД вместе со всеми группами аккаунтов и самими аккаунтами
        public void AddClassToDB(MyDbContext db, IXLWorksheet worksheet, int[] rows)
        {
            //создаем класс
            var class1 = GetClass(worksheet, rows[0], rows[rows.Length-1]+1);
            //добавляем в коллекцию нашу
            db.Classes.Add(class1);

            for(int i = 1; i < rows.Length; i++)
            {
                //создаем группу аккаунтов
                var groupAcc = GetGroupOfAccount(worksheet, rows[i], class1);
                //добавляем эту группу в коллекцию
                db.GroupOfAccounts.Add(groupAcc);
                //добавляем списком все аккаунты этой коллекции
                db.Accounts.AddRange(GetAccounts(worksheet, rows[i-1]+1, rows[i]-1, groupAcc));
            }
        }

        //метод для создания класса
        public MyClass GetClass(IXLWorksheet worksheet, int rowName, int row)
        {
            // По каждой строке формируем объект
            return new MyClass
            {
                Name = worksheet.Cell(rowName, 1).GetValue<string>(),
                SumOpeningBalanceActive = (float)worksheet.Cell(row, 2).GetValue<float>(),
                SumOpeningBalancePassive = (float)worksheet.Cell(row, 3).GetValue<float>(),
                SumTurnoverDebit = (float)worksheet.Cell(row, 4).GetValue<float>(),
                SumTurnoverCredit = (float)worksheet.Cell(row, 5).GetValue<float>(),
                SumOutgoingBalanceActive = (float)worksheet.Cell(row, 6).GetValue<float>(),
                SumOutgoingBalancePassive = (float)worksheet.Cell(row, 7).GetValue<float>(),
            };
        }

        //метод для создания группы аккаунтов
        public GroupOfAccount GetGroupOfAccount(IXLWorksheet worksheet, int row, MyClass myclass)
        {
            // По каждой строке формируем объект
            return new GroupOfAccount
            {
                GroupOfAccountName = worksheet.Cell(row, 1).GetValue<int>(),
                SumOpeningBalanceActive = (float)worksheet.Cell(row, 2).GetValue<float>(),
                SumOpeningBalancePassive = (float)worksheet.Cell(row, 3).GetValue<float>(),
                SumTurnoverDebit = (float)worksheet.Cell(row, 4).GetValue<float>(),
                SumTurnoverCredit = (float)worksheet.Cell(row, 5).GetValue<float>(),
                SumOutgoingBalanceActive = (float)worksheet.Cell(row, 6).GetValue<float>(),
                SumOutgoingBalancePassive = (float)worksheet.Cell(row, 7).GetValue<float>(),
                Class = myclass,
            };
        }

        //метод для создания аккаунтов определенной группы аккаунтов
        public List<Account> GetAccounts(IXLWorksheet worksheet, int startRow, int endRow, GroupOfAccount groupOfAccount)
        {
            var accounts = new List<Account>();
            // Перебираем диапазон нужных строк
            for (int row = startRow; row <= endRow; row++)
            {
                // По каждой строке формируем объект
                var account = new Account
                {
                    AccountNumber = worksheet.Cell(row, 1).GetValue<int>(),
                    OpeningBalanceActive = (float)worksheet.Cell(row, 2).GetValue<float>(),
                    OpeningBalancePassive = (float)worksheet.Cell(row, 3).GetValue<float>(),
                    TurnoverDebit = (float)worksheet.Cell(row, 4).GetValue<float>(),
                    TurnoverCredit = (float)worksheet.Cell(row, 5).GetValue<float>(),
                    OutgoingBalanceActive = (float)worksheet.Cell(row, 6).GetValue<float>(),
                    OutgoingBalancePassive = (float)worksheet.Cell(row, 7).GetValue<float>(),
                    GroupOfAccount = groupOfAccount,
                };
                accounts.Add(account);
            }
            return accounts;
        }

    }

}