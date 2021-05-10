using Employees.Models;
using Employees.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment9.Test
{
    class DepartmentMoq
    {
        [TestCase(11)]
        [TestCase(10)]
        public void CheckDepartmentExistWithMoq(int deptno)
        {
            //Create Fake Object
            var fakeObject = new Mock<IDepartmentAccess>();
            //Set the Mock Configuration
            //The CheckDeptExist() method is call is set with the Integer parameter type
            //The Configuration also defines the Return type from the method  
            fakeObject.Setup(x => x.CheckDeptExist(It.IsAny<int>())).Returns(true);
            //Call the methid
            var Res = fakeObject.Object.CheckDeptExist(deptno);
            Assert.That(Res, Is.True);
        }
        [Test]
        public void GetDepartmentswithMoq()
        {
            //Create Fake Object
            var fakeObject = new Mock<IDepartmentAccess>();
            //Set the Mock Configuration
            //The GetDepartments()
            //The Configuration also defines the Return type from the method  
            List<Department> myList = new List<Department> {  new Department()
            {
                DeptNo = 10,
                Dname = "Account",
                Location = "Ahmdabad",
                Employees = null,
            },
        };

            fakeObject.Setup(x => x.GetDepartments()).Returns(() => myList);

            //Call the methid
            var Res = fakeObject.Object.GetDepartments();
            CollectionAssert.AreEquivalent(Res, myList);
        }
        [Test]
        public void GetDepartmentwithMoq()
        {
            //Create Fake Object
            var fakeObject = new Mock<IDepartmentAccess>();
            //Set the Mock Configuration
            //The GetDepartments()
            //The Configuration also defines the Return type from the method  
            Department myDepartment = new Department()
            {
                DeptNo = 10,
                Dname = "Account",
                Location = "Ahmdabad",
                Employees = null,
            };

            fakeObject.Setup(x => x.GetDepartment(It.IsAny<int>())).Returns(myDepartment);

            //Call the methid
            var Res = fakeObject.Object.GetDepartment(10);
            Assert.AreEqual(Res, myDepartment);
        }
        [Test]
        public void CreateDepartmentwithMoq()
        {
            var fakeObject = new Mock<IDepartmentAccess>();
            //Set the Mock Configuration
            //The CreateDepartment()
            //The Configuration also defines the Return type from the method  
            Department myDepartment = new Department()
            {
                DeptNo = 11,
                Dname = "Payroll",
                Location = "Ahmdabad",
                Employees = null,
            };

            fakeObject.Setup(x => x.CreateDepartment(It.IsAny<Department>())).Returns(true);

            //Call the methid
            var Res = fakeObject.Object.CreateDepartment(myDepartment);
            Assert.That(Res, Is.True);
        }
    }
}
