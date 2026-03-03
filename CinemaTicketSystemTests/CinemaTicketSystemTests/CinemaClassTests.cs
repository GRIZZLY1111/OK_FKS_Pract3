using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CinemaTicketSystem;

namespace CinemaTicketSystemTests
{
    public class CinemaClassTests
    {
        const decimal PRICE_TICKET = 300; // цена билета
        const decimal PRICE_TICKET_CHILDREN_LESS_SIX = 0; //цена билета для детей меньше шести лет
        const decimal PRICE_TICKET_CHILDREN_MORE_SIX_AND_LESS_EIGHTEEN = 180;//цена билета для детей от шести до семнадцати лет
        const decimal PRICE_TICKET_RETIREE_MORE_SIXTY_FIVE = 150;//цена билета для пенсионеров старше шестидесяти пяти лет
        const decimal PRICE_TICKET_ON_WEDNESDAY = 210;//цена билета в среду
        const decimal PRICE_TICKET_IN_THE_MORNING = 255;//цена билета до 12:00
        const decimal PRICE_TICKET_FOR_STUDENT = 240;//цена билета для студента
        const decimal PRICE_TICKET_VIP = 600; // цена VIP билета 
        const decimal PRICE_TICKET_CHILDREN_MORE_SIX_AND_LESS_EIGHTEEN_VIP = 360;//цена VIP билета для детей от шести до семнадцати лет
        const decimal PRICE_TICKET_RETIREE_MORE_SIXTY_FIVE_VIP = 300;//цена VIP билета для пенсионеров старше шестидесяти пяти лет
        const decimal PRICE_TICKET_ON_WEDNESDAY_VIP = 420;//цена VIP билета в среду
        const decimal PRICE_TICKET_IN_THE_MORNING_VIP = 510;//цена VIP билета до 12:00
        const decimal PRICE_TICKET_FOR_STUDENT_VIP = 480;//цена VIP билета для студента
        [Fact]
        public void StandartPriceTicket()
        {
            var TicketRequest = new TicketRequest();
            TicketRequest.Age = 19;
            TicketRequest.IsStudent = false;
            TicketRequest.IsVip = false;
            TicketRequest.Day = DayOfWeek.Monday;
            TicketRequest.SessionTime = TimeSpan.FromHours(13);
            var TicketPriceCalculator = new TicketPriceCalculator();
            Assert.Equal(PRICE_TICKET, TicketPriceCalculator.CalculatePrice(TicketRequest));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void ChildrenSixPriceTicket(int age)
        {
            var TicketRequest = new TicketRequest();
            TicketRequest.Age = age;
            TicketRequest.IsStudent = false;
            TicketRequest.IsVip = false;
            TicketRequest.Day = DayOfWeek.Monday;
            TicketRequest.SessionTime = TimeSpan.FromHours(13);
            var TicketPriceCalculator = new TicketPriceCalculator();
            Assert.Equal(PRICE_TICKET_CHILDREN_LESS_SIX, TicketPriceCalculator.CalculatePrice(TicketRequest));
        }

        [Theory]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(12)]
        [InlineData(16)]
        [InlineData(17)]
        public void ChildrenMoreSixPriceTicket(int age)
        {
            var TicketRequest = new TicketRequest();
            TicketRequest.Age = age;
            TicketRequest.IsStudent = false;
            TicketRequest.IsVip = false;
            TicketRequest.Day = DayOfWeek.Monday;
            TicketRequest.SessionTime = TimeSpan.FromHours(13);
            var TicketPriceCalculator = new TicketPriceCalculator();
            Assert.Equal(PRICE_TICKET_CHILDREN_MORE_SIX_AND_LESS_EIGHTEEN, TicketPriceCalculator.CalculatePrice(TicketRequest));
        }

        [Theory]
        [InlineData(65)]
        [InlineData(78)]
        [InlineData(90)]
        [InlineData(110)]
        [InlineData(120)]
        public void RetireeMoreSixtyFivePriceTicket(int age)
        {
            var TicketRequest = new TicketRequest();
            TicketRequest.Age = age;
            TicketRequest.IsStudent = false;
            TicketRequest.IsVip = false;
            TicketRequest.Day = DayOfWeek.Monday;
            TicketRequest.SessionTime = TimeSpan.FromHours(13);
            var TicketPriceCalculator = new TicketPriceCalculator();
            Assert.Equal(PRICE_TICKET_RETIREE_MORE_SIXTY_FIVE, TicketPriceCalculator.CalculatePrice(TicketRequest));
        }

        [Theory]
        [InlineData(18)]
        [InlineData(19)]
        [InlineData(21)]
        [InlineData(24)]
        [InlineData(25)]
        public void PriceTicketForStudent(int age)
        {
            var TicketRequest = new TicketRequest();
            TicketRequest.Age = age;
            TicketRequest.IsStudent = true;
            TicketRequest.IsVip = false;
            TicketRequest.Day = DayOfWeek.Monday;
            TicketRequest.SessionTime = TimeSpan.FromHours(13);
            var TicketPriceCalculator = new TicketPriceCalculator();
            Assert.Equal(PRICE_TICKET_FOR_STUDENT, TicketPriceCalculator.CalculatePrice(TicketRequest));
        }

        [Fact]
        public void PriceTicketOnWednesday()
        {
            var TicketRequest = new TicketRequest();
            TicketRequest.Age = 25;
            TicketRequest.IsStudent = false;
            TicketRequest.IsVip = false;
            TicketRequest.Day = DayOfWeek.Wednesday;
            TicketRequest.SessionTime = TimeSpan.FromHours(13);
            var TicketPriceCalculator = new TicketPriceCalculator();
            Assert.Equal(PRICE_TICKET_ON_WEDNESDAY, TicketPriceCalculator.CalculatePrice(TicketRequest));
        }

        [Theory]
        [InlineData(11)]
        [InlineData(10)]
        [InlineData(6)]
        [InlineData(1)]
        [InlineData(0)]
        public void PriceTicketInTheMorning(int hour)
        {
            var TicketRequest = new TicketRequest();
            TicketRequest.Age = 25;
            TicketRequest.IsStudent = false;
            TicketRequest.IsVip = false;
            TicketRequest.Day = DayOfWeek.Monday;
            TicketRequest.SessionTime = TimeSpan.FromHours(hour);
            var TicketPriceCalculator = new TicketPriceCalculator();
            Assert.Equal(PRICE_TICKET_IN_THE_MORNING, TicketPriceCalculator.CalculatePrice(TicketRequest));
        }

        [Fact]
        public void StandartPriceTicketVip()
        {
            var TicketRequest = new TicketRequest();
            TicketRequest.Age = 19;
            TicketRequest.IsStudent = false;
            TicketRequest.IsVip = true;
            TicketRequest.Day = DayOfWeek.Monday;
            TicketRequest.SessionTime = TimeSpan.FromHours(13);
            var TicketPriceCalculator = new TicketPriceCalculator();
            Assert.Equal(PRICE_TICKET_VIP, TicketPriceCalculator.CalculatePrice(TicketRequest));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void ChildrenSixPriceTicketVip(int age)
        {
            var TicketRequest = new TicketRequest();
            TicketRequest.Age = age;
            TicketRequest.IsStudent = false;
            TicketRequest.IsVip = true;
            TicketRequest.Day = DayOfWeek.Monday;
            TicketRequest.SessionTime = TimeSpan.FromHours(13);
            var TicketPriceCalculator = new TicketPriceCalculator();
            Assert.Equal(PRICE_TICKET_CHILDREN_LESS_SIX, TicketPriceCalculator.CalculatePrice(TicketRequest));
        }

        [Theory]
        [InlineData(6)]
        [InlineData(9)]
        [InlineData(12)]
        [InlineData(14)]
        [InlineData(17)]
        public void ChildrenMoreSixPriceTicketVip(int age)
        {
            var TicketRequest = new TicketRequest();
            TicketRequest.Age = age;
            TicketRequest.IsStudent = false;
            TicketRequest.IsVip = true;
            TicketRequest.Day = DayOfWeek.Monday;
            TicketRequest.SessionTime = TimeSpan.FromHours(13);
            var TicketPriceCalculator = new TicketPriceCalculator();
            Assert.Equal(PRICE_TICKET_CHILDREN_MORE_SIX_AND_LESS_EIGHTEEN_VIP, TicketPriceCalculator.CalculatePrice(TicketRequest));
        }

        [Theory]
        [InlineData(67)]
        [InlineData(78)]
        [InlineData(90)]
        [InlineData(110)]
        [InlineData(120)]
        public void RetireeMoreSixtyFivePriceTicketVip(int age)
        {
            var TicketRequest = new TicketRequest();
            TicketRequest.Age = age;
            TicketRequest.IsStudent = false;
            TicketRequest.IsVip = true;
            TicketRequest.Day = DayOfWeek.Monday;
            TicketRequest.SessionTime = TimeSpan.FromHours(13);
            var TicketPriceCalculator = new TicketPriceCalculator();
            Assert.Equal(PRICE_TICKET_RETIREE_MORE_SIXTY_FIVE_VIP, TicketPriceCalculator.CalculatePrice(TicketRequest));
        }

        [Theory]
        [InlineData(18)]
        [InlineData(19)]
        [InlineData(21)]
        [InlineData(24)]
        [InlineData(25)]
        public void PriceTicketForStudentVip(int age)
        {
            var TicketRequest = new TicketRequest();
            TicketRequest.Age = age;
            TicketRequest.IsStudent = true;
            TicketRequest.IsVip = true;
            TicketRequest.Day = DayOfWeek.Monday;
            TicketRequest.SessionTime = TimeSpan.FromHours(13);
            var TicketPriceCalculator = new TicketPriceCalculator();
            Assert.Equal(PRICE_TICKET_FOR_STUDENT_VIP, TicketPriceCalculator.CalculatePrice(TicketRequest));
        }

        [Fact]
        public void PriceTicketOnWednesdayVip()
        {
            var TicketRequest = new TicketRequest();
            TicketRequest.Age = 25;
            TicketRequest.IsStudent = false;
            TicketRequest.IsVip = true;
            TicketRequest.Day = DayOfWeek.Wednesday;
            TicketRequest.SessionTime = TimeSpan.FromHours(13);
            var TicketPriceCalculator = new TicketPriceCalculator();
            Assert.Equal(PRICE_TICKET_ON_WEDNESDAY_VIP, TicketPriceCalculator.CalculatePrice(TicketRequest));
        }

        [Theory]
        [InlineData(11)]
        [InlineData(10)]
        [InlineData(6)]
        [InlineData(3)]
        [InlineData(0)]
        public void PriceTicketInTheMorningVip(int hour)
        {
            var TicketRequest = new TicketRequest();
            TicketRequest.Age = 25;
            TicketRequest.IsStudent = false;
            TicketRequest.IsVip = true;
            TicketRequest.Day = DayOfWeek.Monday;
            TicketRequest.SessionTime = TimeSpan.FromHours(hour);
            var TicketPriceCalculator = new TicketPriceCalculator();
            Assert.Equal(PRICE_TICKET_IN_THE_MORNING_VIP, TicketPriceCalculator.CalculatePrice(TicketRequest));
        }
        [Fact]
        public void ReturnArgumentNullException()
        {
            var TicketRequest = new TicketRequest();
            TicketRequest = null;
            var TicketPriceCalculator = new TicketPriceCalculator();
            Assert.Throws<ArgumentNullException>(
                () => TicketPriceCalculator.CalculatePrice(TicketRequest)
                );
        }
        [Fact]
        public void ReturnArgumentOutOfRangeExceptionAgeLessZero()
        {
            var TicketRequest = new TicketRequest();
            TicketRequest.Age = -1;
            TicketRequest.IsStudent = false;
            TicketRequest.IsVip = false;
            TicketRequest.Day = DayOfWeek.Monday;
            TicketRequest.SessionTime = TimeSpan.FromHours(13);
            var TicketPriceCalculator = new TicketPriceCalculator();
            Assert.Throws<ArgumentOutOfRangeException>(
                ()=>TicketPriceCalculator.CalculatePrice(TicketRequest)
                );
        }

        [Fact]
        public void ReturnArgumentOutOfRangeExceptionAgeMoreHundredTwenty()
        {
            var TicketRequest = new TicketRequest();
            TicketRequest.Age = 121;
            TicketRequest.IsStudent = false;
            TicketRequest.IsVip = false;
            TicketRequest.Day = DayOfWeek.Monday;
            TicketRequest.SessionTime = TimeSpan.FromHours(13);
            var TicketPriceCalculator = new TicketPriceCalculator();
            Assert.Throws<ArgumentOutOfRangeException>(
                () => TicketPriceCalculator.CalculatePrice(TicketRequest)
                );
        }

        [Fact]
        public void ChildrenLessSixAbsoluteDiscount()
        {
            var TicketRequest = new TicketRequest();
            TicketRequest.Age = 4;
            TicketRequest.IsStudent = false;
            TicketRequest.IsVip = false;
            TicketRequest.Day = DayOfWeek.Wednesday;
            TicketRequest.SessionTime = TimeSpan.FromHours(10);
            var TicketPriceCalculator = new TicketPriceCalculator();
            Assert.Equal(PRICE_TICKET_CHILDREN_LESS_SIX, TicketPriceCalculator.CalculatePrice(TicketRequest));
        }

        [Fact]
        public void ChildrenMoreSixMaxDiscount()
        {
            var TicketRequest = new TicketRequest();
            TicketRequest.Age = 10;
            TicketRequest.IsStudent = true;
            TicketRequest.IsVip = false;
            TicketRequest.Day = DayOfWeek.Wednesday;
            TicketRequest.SessionTime = TimeSpan.FromHours(10);
            var TicketPriceCalculator = new TicketPriceCalculator();
            Assert.Equal(PRICE_TICKET_CHILDREN_MORE_SIX_AND_LESS_EIGHTEEN, TicketPriceCalculator.CalculatePrice(TicketRequest));
        }

        [Fact]
        public void RetireeMoreSixtyFiveMaxDiscount()
        {
            var TicketRequest = new TicketRequest();
            TicketRequest.Age = 75;
            TicketRequest.IsStudent = true;
            TicketRequest.IsVip = false;
            TicketRequest.Day = DayOfWeek.Wednesday;
            TicketRequest.SessionTime = TimeSpan.FromHours(10);
            var TicketPriceCalculator = new TicketPriceCalculator();
            Assert.Equal(PRICE_TICKET_RETIREE_MORE_SIXTY_FIVE, TicketPriceCalculator.CalculatePrice(TicketRequest));
        }

        [Fact]
        public void WednesdayDiscountMaxDiscount()
        {
            var TicketRequest = new TicketRequest();
            TicketRequest.Age = 21;
            TicketRequest.IsStudent = true;
            TicketRequest.IsVip = false;
            TicketRequest.Day = DayOfWeek.Wednesday;
            TicketRequest.SessionTime = TimeSpan.FromHours(11);
            var TicketPriceCalculator = new TicketPriceCalculator();
            Assert.Equal(PRICE_TICKET_ON_WEDNESDAY, TicketPriceCalculator.CalculatePrice(TicketRequest));
        }

        [Fact]
        public void StudentDiscountMaxDiscount()
        {
            var TicketRequest = new TicketRequest();
            TicketRequest.Age = 21;
            TicketRequest.IsStudent = true;
            TicketRequest.IsVip = false;
            TicketRequest.Day = DayOfWeek.Monday;
            TicketRequest.SessionTime = TimeSpan.FromHours(11);
            var TicketPriceCalculator = new TicketPriceCalculator();
            Assert.Equal(PRICE_TICKET_FOR_STUDENT, TicketPriceCalculator.CalculatePrice(TicketRequest));
        }


        [Fact]
        public void StudentBeyondeBorderValues()
        {
            var TicketRequest = new TicketRequest();
            TicketRequest.Age = 26;
            TicketRequest.IsStudent = true;
            TicketRequest.IsVip = false;
            TicketRequest.Day = DayOfWeek.Monday;
            TicketRequest.SessionTime = TimeSpan.FromHours(13);
            var TicketPriceCalculator = new TicketPriceCalculator();
            Assert.Equal(PRICE_TICKET, TicketPriceCalculator.CalculatePrice(TicketRequest));
        }
    }
}