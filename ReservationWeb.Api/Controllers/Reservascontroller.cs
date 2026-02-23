using Microsoft.AspNetCore.Mvc;
using ReservationWeb.Mvc.Models;
using ReservationWeb.Mvc.Services;
using System;
using System.Threading.Tasks;

namespace ReservationWeb.Mvc.Controllers
{
    public class ReservasController : Controller
    {
        private readonly IReservationApiService _apiService;

        public ReservasController(IReservationApiService apiService)
        {
            _apiService = apiService;
        }

        // GET: /Reservas
        public async Task<IActionResult> Index()
        {
            var reservas = await _apiService.GetAllAsync();
            return View(reservas);
        }

        // GET: /Reservas/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var reserva = await _apiService.GetByIdAsync(id);
            if (reserva == null) return NotFound();
            return View(reserva);
        }

        // GET: /Reservas/Create
        public IActionResult Create()
        {
            return View(new ReservationFormViewModel());
        }

        // POST: /Reservas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReservationFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                await _apiService.CreateAsync(model);
                TempData["Exito"] = "Reserva creada exitosamente.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error al crear la reserva: {ex.Message}");
                return View(model);
            }
        }

        // GET: /Reservas/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var reserva = await _apiService.GetByIdAsync(id);
            if (reserva == null) return NotFound();

            var model = new ReservationFormViewModel
            {
                Id = reserva.Id,
                Paciente = reserva.Paciente,
                Medico = reserva.Medico,
                Especialidad = reserva.Especialidad,
                Fecha = reserva.Fecha
            };
            return View(model);
        }

        // POST: /Reservas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ReservationFormViewModel model)
        {
            if (id != model.Id) return BadRequest();

            if (!ModelState.IsValid)
                return View(model);

            try
            {
                await _apiService.UpdateAsync(model);
                TempData["Exito"] = "Reserva actualizada exitosamente.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error al actualizar: {ex.Message}");
                return View(model);
            }
        }

        // GET: /Reservas/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var reserva = await _apiService.GetByIdAsync(id);
            if (reserva == null) return NotFound();
            return View(reserva);
        }

        // POST: /Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _apiService.DeleteAsync(id);
                TempData["Exito"] = "Reserva eliminada exitosamente.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al eliminar: {ex.Message}";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}