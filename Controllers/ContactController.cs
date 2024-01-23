using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using contacts_app.Data;
using contacts_app.Models;
using contacts_app.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;

namespace contacts_app.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public IActionResult Index()
        {
            List<ContactModel> contacts = _contactRepository.FindAll();
            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update(int id)
        {
            ContactModel contact = _contactRepository.FindById(id);
            return View(contact);
        }

        public IActionResult Delete(int id)
        {
            ContactModel contact = _contactRepository.FindById(id);
            return View(contact);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        [HttpPost]
        public IActionResult Create(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepository.Add(contact);
                    TempData["SuccessMessage"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(contact);
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = $"Erro ao cadastrar contato. {error.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Update(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepository.Update(contact);
                    TempData["SuccessMessage"] = "Contato atualizado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(contact);
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = $"Erro ao atualizar contato. {error.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Delete(ContactModel contact)
        {
            try
            {

                _contactRepository.Delete(contact);
                TempData["SuccessMessage"] = "Contato deletado com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = $"Erro ao deletar contato. {error.Message}";
                return RedirectToAction("Index");
            }


        }
    }
}