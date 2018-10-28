using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using MVCWithADO.Models;
using System.Data;

namespace MVCWithADO.Controllers
{
	public class StudentController : Controller
	{
		/// <summary>
		/// Get all Students from the DB
		/// </summary>
		/// <returns>Index View</returns>
		public ActionResult Index()
		{
			StudentModel studModel = new StudentModel();
			DataTable dt = studModel.GetAllStudents();
			return View("Index", dt);
		}

		/// <summary>
		/// Action method, called when the "Add New Record" link clicked
		/// </summary>
		/// <returns>Create View</returns>
		public ActionResult Insert()
		{
			return View("Create");
		}

		/// <summary>
		/// Action method, called when the user cklicked "Submit" button
		/// </summary>
		/// <param name="frm">Form Collection Object</param>
		/// <param name="action">Used to differentiate between "Submit" and "Cancel"</param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult InsertRecord(FormCollection frm, string action)
		{
			if (action == "Submit")
			{
				StudentModel model = new StudentModel();
				string name = frm["txtName"];
				int age = Convert.ToInt32(frm["txtAge"]);
				string gender = frm["txtGender"];
				int status = model.InsertStudent(name, gender, age);
				return RedirectToAction("Index");
			}
			else
			{
				return RedirectToAction("Index");
			}
		}

		/// <summary>
		/// Action method, called when the user click "Edit" Link
		/// </summary>
		/// <param name="StudentID">Student ID</param>
		/// <returns>Edit View</returns>
		public ActionResult Edit(int StudentID)
		{
			StudentModel model = new StudentModel();
			DataTable dt = model.GetStudentById(StudentID);
			return View("Edit", dt);
		}

		/// <summary>
		/// Action method, called when the user updated the record or canceled the update.
		/// </summary>
		/// <param name="frm">Form Collection</param>
		/// <param name="action">Denotes the action</param>
		/// <returns>Index View</returns>
		public ActionResult UpdateRecord(FormCollection frm, string action)
		{
			if(action == "Submit")
			{
				StudentModel model = new StudentModel();
				string name = frm["txtName"];
				int age = Convert.ToInt32(frm["txtAge"]);
				string gender = frm["txtGender"];
				int id = Convert.ToInt32(frm["hdnID"]);
				int status = model.UpdateStudent(id, name, gender, age);
				return RedirectToAction("Index");
			}
			else
			{
				return RedirectToAction("Index");
			}
		}

		/// <summary>
		/// Action method, called when the "Delete" link clicked
		/// </summary>
		/// <param name="StudentId">Student ID to edit</param>
		/// <returns>Index View</returns>
		public ActionResult Delete(int StudentId)
		{
			StudentModel model = new StudentModel();
			model.DeleteStudent(StudentId);
			return RedirectToAction("Index");
		}
	}
}