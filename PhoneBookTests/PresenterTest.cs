using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DXApplication1.Presenter;
using DXApplication1.View;
using DXApplication1.Model;
using Moq;
using System.ComponentModel;
using System.Windows.Forms;

namespace PhoneBookTests
{
    [TestClass]
    public class PresenterTest
    {
        PhoneBookPresenter presenter;

        Mock<IView> mockView;
        Mock<IRepository> mockRepository;
        Mock<PhoneBookPresenter> mockPresenter;
        BindingList<Contact> stubRepositoryList;

        [TestInitialize]
        public void Initialize()
        {
            mockView = new Mock<IView>();
            mockRepository = new Mock<IRepository>();
            mockPresenter = new Mock<PhoneBookPresenter>();

            BindingSource stubSource = new BindingSource();
            mockView.Setup(x => x.bindingSource).Returns(stubSource);

            presenter = new PhoneBookPresenter(mockView.Object, mockRepository.Object);

            stubRepositoryList = new BindingList<Contact>()
            {
                new Contact(){ fullName = "Иван Иванов", Phone = "0662345634", id = 1},
                new Contact(){ fullName = "Петр Петров", Phone = "0995673486", id = 2},
                new Contact(){ fullName = "Мария Марьяновна", Phone = "0950983675", id = 3},
                new Contact(){ fullName = "Александра Александрова", Phone = "0670984707", id = 4}
            };
        }

        [TestMethod]
        public void UpdateContactListView_DataSourceDefinition_DataBindingMethodShouldBeCalled()
        {
            mockRepository.Setup(x => x.GetAllContacts());
            mockView.Setup(x => x.SetDatasource(stubRepositoryList));

            presenter.UpdateContactListView();

            mockRepository.VerifyAll();
            mockView.VerifyAll();      
        }

        [TestMethod]
        public void DeleteContact_FocusedContactDeletingFromRepositoriAndView_ContactShouldBeDeleted()
        {
            //mockPresenter.Setup(x => x.viewContacts).Returns(stubRepositoryList);
            mockRepository.Setup(x => x.contacts).Returns(stubRepositoryList);

            int stubContactId = 2;
            presenter.DeleteContact(stubContactId);

            BindingList<Contact> newStubRepositoryList = new BindingList<Contact>()
            {
                new Contact(){ fullName = "Иван Иванов", Phone = "0662345634", id = 1},
                new Contact(){ fullName = "Мария Марьяновна", Phone = "0950983675", id = 3},
                new Contact(){ fullName = "Александра Александрова", Phone = "0670984707", id = 4}
            };

            //mockPresenter.VerifySet(x => x.viewContacts = It.Is<BindingList<Contact>>(y => y.Equals(newStubRepositoryList)));
            mockRepository.VerifySet(x => x.contacts = It.Is<BindingList<Contact>>(y => y.Equals(newStubRepositoryList)));
        }
    }
}
