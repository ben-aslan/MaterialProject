using MaterialProject.Models;
using MaterialProject.MyDBDataSetTableAdapters;
using OfficeOpenXml.Style;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MaterialProject.MyDBDataSet;
using System.Collections;

namespace MaterialProject
{
    public partial class UserHome : Form
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        TaskDataTable _tasks;
        List<int> _cars;
        string excelFilePath;

        public UserHome(List<int> cars)
        {
            InitializeComponent();
            using (var taskAdapter = new TaskTableAdapter())
                _tasks = taskAdapter.GetData();
            _cars = cars;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var carTaskAdapter = new TaskCarsTableAdapter())
            {
                var tasks = carTaskAdapter.GetData().Where(x => _cars.Contains(x.CarID)).Select(x => x.TaskID).ToList();
                var task = _tasks.FirstOrDefault(x => tasks.Contains(x.ID) && (x.TaskNo.Trim() == textBox1.Text.Trim() || x.TaskNo.Trim() == textBox1.Text.Replace("-", "‐").Trim()));
                if (task != null)
                {
                    if (dataGridView2.Rows.Cast<DataGridViewRow>().Any(x => x.Cells[0].Value.ToString() == task.TaskNo))
                    {
                        MessageBox.Show("This task is exist".ToUpper(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    dataGridView2.Rows.Add(new string[] { task.TaskNo });
                }
                else
                {
                    MessageBox.Show("This task not found".ToUpper(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        async Task ExportExcelFile(IProgress<ProgressReportModel> progress, CancellationToken cancellation)
        {
            var progressReport = new ProgressReportModel();

            using (var saveFileDialog = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            using (var tasks = new TaskTableAdapter())
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    excelFilePath = saveFileDialog.FileName;
                    button9.Enabled = true;
                    using (var excel = new ExcelPackage(new System.IO.FileInfo(saveFileDialog.FileName)))
                    {
                        var excelWorksheet = excel.Workbook.Worksheets.Add("Sheet1".ToUpper());

                        int startRow = 0;
                        int endRow = 0;
                        startRow += 1;
                        endRow += 1;

                        int startCol = 0;
                        int endCol = 0;
                        startCol += 1;
                        endCol += 2;

                        using (var range = excelWorksheet.Cells[1, startCol, 1, endCol])
                        using (var rangeCol2 = excelWorksheet.Cells[2, startCol, 2, endCol])
                        {
                            range.Merge = true;
                            range.Value = "Task".ToUpper();
                            range.Style.Font.Bold = true;
                            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            range.Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                            range.Style.Font.Color.SetColor(Color.Black);

                            rangeCol2.Style.Font.Bold = true;
                            rangeCol2.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rangeCol2.Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                            rangeCol2.Style.Font.Color.SetColor(Color.Black);

                            excelWorksheet.Cells[2, startCol].Value = "Task No".ToUpper();
                            excelWorksheet.Cells[2, startCol + 1].Value = "Ad No".ToUpper();
                        }
                        startCol += 2;

                        cancellation.ThrowIfCancellationRequested();
                        progressReport.PercentageComplete = 10;
                        progressReport.Description = "Adding task headers".ToUpper();
                        progress.Report(progressReport);

                        endCol += 1;
                        using (var range = excelWorksheet.Cells[1, startCol, 1, endCol])
                        using (var rangeCol2 = excelWorksheet.Cells[2, startCol, 2, endCol])
                        {
                            range.Merge = true;
                            range.Value = "".ToUpper();
                            range.Style.Font.Bold = true;
                            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            range.Style.Fill.BackgroundColor.SetColor(Color.Orange);
                            range.Style.Font.Color.SetColor(Color.Black);

                            rangeCol2.Style.Font.Bold = true;
                            rangeCol2.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rangeCol2.Style.Fill.BackgroundColor.SetColor(Color.Orange);
                            rangeCol2.Style.Font.Color.SetColor(Color.Black);

                            excelWorksheet.Cells[2, startCol].Value = "ACCESS PANELS NO".ToUpper();
                        }
                        startCol += 1;

                        cancellation.ThrowIfCancellationRequested();
                        progressReport.PercentageComplete = 20;
                        progressReport.Description = "Adding access no headers".ToUpper();
                        progress.Report(progressReport);

                        endCol += 3;
                        using (var range = excelWorksheet.Cells[1, startCol, 1, endCol])
                        using (var rangeCol2 = excelWorksheet.Cells[2, startCol, 2, endCol])
                        {
                            range.Merge = true;
                            range.Value = "Consumable Materials".ToUpper();
                            range.Style.Font.Bold = true;
                            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            range.Style.Fill.BackgroundColor.SetColor(Color.Purple);
                            range.Style.Font.Color.SetColor(Color.Black);

                            rangeCol2.Style.Font.Bold = true;
                            rangeCol2.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rangeCol2.Style.Fill.BackgroundColor.SetColor(Color.Purple);
                            rangeCol2.Style.Font.Color.SetColor(Color.Black);

                            excelWorksheet.Cells[2, startCol].Value = "Part No".ToUpper();
                            //excelWorksheet.Cells[2, startCol + 1].Value = "Access No";
                            excelWorksheet.Cells[2, startCol + 1].Value = "QTY".ToUpper();
                            excelWorksheet.Cells[2, startCol + 2].Value = "Description".ToUpper();
                        }
                        startCol += 3;

                        cancellation.ThrowIfCancellationRequested();
                        progressReport.PercentageComplete = 30;
                        progressReport.Description = "Adding consumable materials headers".ToUpper();
                        progress.Report(progressReport);

                        endCol += 3;
                        using (var range = excelWorksheet.Cells[1, startCol, 1, endCol])
                        using (var rangeCol2 = excelWorksheet.Cells[2, startCol, 2, endCol])
                        {
                            range.Merge = true;
                            range.Value = "PARTS Requirement".ToUpper();
                            range.Style.Font.Bold = true;
                            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            range.Style.Fill.BackgroundColor.SetColor(Color.Green);
                            range.Style.Font.Color.SetColor(Color.Black);

                            rangeCol2.Style.Font.Bold = true;
                            rangeCol2.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rangeCol2.Style.Fill.BackgroundColor.SetColor(Color.Green);
                            rangeCol2.Style.Font.Color.SetColor(Color.Black);

                            excelWorksheet.Cells[2, startCol].Value = "Part No".ToUpper();
                            excelWorksheet.Cells[2, startCol + 1].Value = "QTY".ToUpper();
                            excelWorksheet.Cells[2, startCol + 2].Value = "Description".ToUpper();
                        }
                        startCol += 3;

                        cancellation.ThrowIfCancellationRequested();
                        progressReport.PercentageComplete = 40;
                        progressReport.Description = "Adding PARTS requirement headers".ToUpper();
                        progress.Report(progressReport);

                        endCol += 2;
                        using (var range = excelWorksheet.Cells[1, startCol, 1, endCol])
                        using (var rangeCol2 = excelWorksheet.Cells[2, startCol, 2, endCol])
                        {
                            range.Merge = true;
                            range.Value = "Tools And Testers".ToUpper();
                            range.Style.Font.Bold = true;
                            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            range.Style.Fill.BackgroundColor.SetColor(Color.Pink);
                            range.Style.Font.Color.SetColor(Color.Black);

                            rangeCol2.Style.Font.Bold = true;
                            rangeCol2.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rangeCol2.Style.Fill.BackgroundColor.SetColor(Color.Pink);
                            rangeCol2.Style.Font.Color.SetColor(Color.Black);
                            //rangeCol2.Style.Numberformat.Format=

                            excelWorksheet.Cells[2, startCol].Value = "Part No".ToUpper();
                            excelWorksheet.Cells[2, startCol + 1].Value = "Description".ToUpper();
                        }
                        startCol += 2;

                        endCol += 2;
                        using (var range = excelWorksheet.Cells[1, startCol, 1, endCol])
                        using (var rangeCol2 = excelWorksheet.Cells[2, startCol, 2, endCol])
                        {
                            range.Merge = true;
                            range.Value = "NDT REQUIREMENT".ToUpper();
                            range.Style.Font.Bold = true;
                            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            range.Style.Fill.BackgroundColor.SetColor(Color.Red);
                            range.Style.Font.Color.SetColor(Color.Black);

                            rangeCol2.Style.Font.Bold = true;
                            rangeCol2.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rangeCol2.Style.Fill.BackgroundColor.SetColor(Color.Red);
                            rangeCol2.Style.Font.Color.SetColor(Color.Black);
                            //rangeCol2.Style.Numberformat.Format=

                            excelWorksheet.Cells[2, startCol].Value = "Type".ToUpper();
                            excelWorksheet.Cells[2, startCol + 1].Value = "Remark".ToUpper();
                        }
                        startCol += 2;

                        cancellation.ThrowIfCancellationRequested();
                        progressReport.PercentageComplete = 50;
                        progressReport.Description = "Adding tools and testers headers".ToUpper();
                        progress.Report(progressReport);

                        endCol += 1;
                        using (var range = excelWorksheet.Cells[1, startCol, 1, endCol])
                        using (var rangeCol2 = excelWorksheet.Cells[2, startCol, 2, endCol])
                        {
                            range.Merge = true;
                            range.Value = "Remark".ToUpper();
                            range.Style.Font.Bold = true;
                            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            range.Style.Fill.BackgroundColor.SetColor(Color.Blue);
                            range.Style.Font.Color.SetColor(Color.Black);

                            rangeCol2.Style.Font.Bold = true;
                            rangeCol2.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rangeCol2.Style.Fill.BackgroundColor.SetColor(Color.Blue);
                            rangeCol2.Style.Font.Color.SetColor(Color.Black);
                            //rangeCol2.Style.Numberformat.Format=

                            excelWorksheet.Cells[2, startCol].Value = "Remark".ToUpper();
                        }
                        startCol += 1;



                        using (var accessPanels = new Access_PanelTableAdapter())
                        using (var consumableMaterials = new CunsumableMaterialsTableAdapter())
                        using (var partRequirements = new Part_RequirementTableAdapter())
                        using (var toolAndTesters = new Tools_And_TestersTableAdapter())
                        using (var ndtsTableAdapter = new NDTsTableAdapter())
                        using (var taskNDTsTableAdapter = new TaskNDTsTableAdapter())
                        {
                            var taskIds = new List<string>();
                            var adNoIds = new List<string>();
                            for (int i = 0; i < dataGridView2.RowCount; i++)
                            {
                                taskIds.Add(dataGridView2.Rows[i].Cells[0].Value.ToString());
                            }
                            for (int i = 0; i < dataGridView1.RowCount; i++)
                            {
                                adNoIds.Add(dataGridView1.Rows[i].Cells[0].Value.ToString());
                            }
                            var carTasks = new TaskCarsTableAdapter().GetData().Where(x => _cars.Contains(x.CarID)).ToList();
                            var taskDtos = tasks.GetData().ToList().Where(x => ((taskIds.Any(ti => ti == x.TaskNo) || adNoIds.Any(ani => ani == x.ADNo)) && carTasks.Any(ct => ct.TaskID == x.ID))).Select(x => new TaskDto { Id = x.ID, TaskNo = x.TaskNo, AdNo = x.ADNo, Remarks = x.Remarks, NDTRemark = x.NDTRemark }).ToList();
                            var accessPanelDtos = accessPanels.GetData().Select(x => new AccessPanelDto { Id = x.ID, AccessNo = x.AccessNo, TaskId = x.Table1ID }).ToList();
                            var consumableMaterialsDtos = consumableMaterials.GetData().Select(x => new ConsumableMaterialDto { Id = x.ID, PartNo = x.PartNo, AccessNo = x.AccessNo, QTY = x.QTY, Description = x.Description, TaskId = x.Table1ID }).ToList();
                            var partRequirementDtos = partRequirements.GetData().Select(x => new PartRequirementDto { Id = x.ID, PartNo = x.PartNo, QTY = x.QTY, Description = x.Description, TaskId = x.Table1ID }).ToList();
                            var toolAndTesterDtos = toolAndTesters.GetData().Select(x => new ToolAndTesterDto { Id = x.ID, PartNo = x.PartNo, Description = x.Description, TaskId = x.Table1ID }).ToList();

                            var ndts = ndtsTableAdapter.GetData();
                            var taskNDTs = taskNDTsTableAdapter.GetData();

                            Parallel.ForEach(taskDtos, (task) =>
                            {
                                task.AccessPanels = new List<AccessPanelDto>();
                                task.AccessPanels.AddRange(accessPanelDtos.Where(x => x.TaskId == task.Id).ToList());
                                task.ConsumableMaterials = new List<ConsumableMaterialDto>();
                                task.ConsumableMaterials.AddRange(consumableMaterialsDtos.Where(x => x.TaskId == task.Id).ToList());
                                task.PartRequirements = new List<PartRequirementDto>();
                                task.PartRequirements.AddRange(partRequirementDtos.Where(x => x.TaskId == task.Id).ToList());
                                task.ToolAndTesters = new List<ToolAndTesterDto>();
                                task.ToolAndTesters.AddRange(toolAndTesterDtos.Where(x => x.TaskId == task.Id).ToList());
                                task.NDTs = new List<NDTDto>();
                                task.NDTs.AddRange(taskNDTs.Where(x => x.TaskID == task.Id).Select(x => new NDTDto { Type = ndts.Where(ndt => ndt.ID == x.NDTID).Select(ndt => ndt.Type).First() }).ToList());
                            });

                            startRow += 2;
                            endRow += 2;

                            foreach (var task in taskDtos)
                            {
                                startCol = 1;
                                endCol = 2;

                                excelWorksheet.Cells[startRow, startCol].Value = task.TaskNo;
                                excelWorksheet.Cells[startRow, startCol + 1].Value = task.AdNo;

                                startCol += 2;
                                endCol += 2;

                                cancellation.ThrowIfCancellationRequested();
                                progressReport.PercentageComplete = 60;
                                progressReport.Description = "Adding access panels".ToUpper();
                                progress.Report(progressReport);

                                foreach (var accessPanel in task.AccessPanels)
                                {
                                    startRow += 1;
                                    endRow += 1;

                                    excelWorksheet.Cells[startRow, startCol].Value = accessPanel.AccessNo;
                                }
                                startCol += 1;
                                endCol += 1;

                                cancellation.ThrowIfCancellationRequested();
                                progressReport.PercentageComplete = 70;
                                progressReport.Description = "Adding Consimable panels".ToUpper();
                                progress.Report(progressReport);

                                foreach (var consumableMaterial in task.ConsumableMaterials)
                                {
                                    startRow += 1;
                                    endRow += 1;

                                    excelWorksheet.Cells[startRow, startCol].Value = consumableMaterial.PartNo;
                                    //excelWorksheet.Cells[startRow, startCol + 1].Value = consumableMaterial.AccessNo;
                                    excelWorksheet.Cells[startRow, startCol + 1].Value = consumableMaterial.QTY;
                                    excelWorksheet.Cells[startRow, startCol + 2].Value = consumableMaterial.Description;
                                }
                                startCol += 3;
                                endCol += 3;

                                cancellation.ThrowIfCancellationRequested();
                                progressReport.PercentageComplete = 80;
                                progressReport.Description = "Adding part requirements".ToUpper();
                                progress.Report(progressReport);

                                foreach (var partRequirement in task.PartRequirements)
                                {
                                    startRow += 1;
                                    endRow += 1;

                                    excelWorksheet.Cells[startRow, startCol].Value = partRequirement.PartNo;
                                    excelWorksheet.Cells[startRow, startCol + 1].Value = partRequirement.QTY;
                                    excelWorksheet.Cells[startRow, startCol + 2].Value = partRequirement.Description;
                                }
                                startCol += 3;
                                endCol += 3;

                                cancellation.ThrowIfCancellationRequested();
                                progressReport.PercentageComplete = 90;
                                progressReport.Description = "Adding tools and testers".ToUpper();
                                progress.Report(progressReport);

                                foreach (var ToolAndTester in task.ToolAndTesters)
                                {
                                    startRow += 1;
                                    endRow += 1;

                                    excelWorksheet.Cells[startRow, startCol].Value = ToolAndTester.PartNo;
                                    excelWorksheet.Cells[startRow, startCol + 1].Value = ToolAndTester.Description;
                                }

                                startCol += 2;
                                endCol += 2;

                                foreach (var ndt in task.NDTs)
                                {
                                    startRow += 1;
                                    endRow += 1;

                                    excelWorksheet.Cells[startRow, startCol].Value = ndt.Type;
                                }
                                using (var rangeCol2 = excelWorksheet.Cells[startRow - task.NDTs.Count + 1, endCol, endRow, endCol])
                                {
                                    if ((startRow - task.NDTs.Count + 1) <= endRow)
                                        rangeCol2.Merge = true;
                                    rangeCol2.Value = task.NDTRemark;
                                }

                                startCol += 2;
                                endCol += 2;

                                startRow += 1;
                                endRow += 1;

                                excelWorksheet.Cells[startRow, startCol].Value = task.Remarks;

                                startRow += 3;
                                endRow += 3;
                            }
                        }

                        cancellation.ThrowIfCancellationRequested();
                        progressReport.PercentageComplete = 99;
                        progressReport.Description = "Saving".ToUpper();
                        progress.Report(progressReport);

                        excelWorksheet.Cells[1, 1, endRow, endCol].AutoFitColumns();

                        await excel.SaveAsync();

                        cancellation.ThrowIfCancellationRequested();
                        progressReport.PercentageComplete = 100;
                        progressReport.Description = "Complete".ToUpper();
                        progress.Report(progressReport);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var progress = new Progress<ProgressReportModel>();
            progress.ProgressChanged += Progress_ProgressChanged;

            var exportTask = ExportExcelFile(progress, cts.Token);
            cancelBtn.Enabled = true;
        }

        private void Progress_ProgressChanged(object sender, ProgressReportModel e)
        {
            progressBar1.Value = e.PercentageComplete;
            label1.Text = e.Description;
            Task.Run(() => { if (e.PercentageComplete == 100) cancelBtn.Enabled = false; });
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            cts.Cancel();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            new UserTaskDetails(dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells[0].Value.ToString(), _cars).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var carTaskAdapter = new TaskCarsTableAdapter())
            {
                var tasks = carTaskAdapter.GetData().Where(x => _cars.Contains(x.CarID)).Select(x => x.TaskID).ToList();
                var task = _tasks.FirstOrDefault(x => tasks.Contains(x.ID) && (x.ADNo.Trim() == textBox2.Text.Trim() || x.ADNo.Trim() == textBox2.Text.Replace("-", "‐").Trim()));
                if (task != null)
                {
                    if (dataGridView1.Rows.Cast<DataGridViewRow>().Any(x => x.Cells[0].Value.ToString() == task.ADNo))
                    {
                        MessageBox.Show("This task is exist".ToUpper(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    dataGridView1.Rows.Add(new string[] { task.ADNo });
                }
                else
                {
                    MessageBox.Show("This task not found".ToUpper(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            new UserAdNoDetail(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value.ToString(), _cars).Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.RemoveAt(dataGridView2.SelectedCells[0].RowIndex);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedCells[0].RowIndex);
        }

        private void UserHome_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(excelFilePath);
        }
    }
}
