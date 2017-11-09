using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Web.Mvc;
using System.Data;
using System.Web;

namespace DMSys.Web.PageGenerate
{
    public static class PGenerate
    {
        public static void HtmlLabel(StringBuilder container, string name, string text)
        {
            container.AppendLine("<label" +
                ((name == "") ? "" : " for='" + name + "'") + ">" + text + "</label>");
        }

        public static void HtmlButton(StringBuilder container, string name, string text, string type, string cssClass = "")
        {
            container.AppendLine("<button name='" + name + "' type='" + type + "'" +
                ((cssClass == "") ? "" : " class='" + cssClass + "'") + ">" + text + "</button>");
        }

        public static void HtmlLink(StringBuilder container, string name, string text, string href, string cssClass = "")
        {
            container.AppendLine("<a id='" + name + "' href='" + href + "'" +
                ((cssClass == "") ? "" : " class='" + cssClass + "'") + ">" + text + "</a>");
        }

        public static void HtmlInput(StringBuilder container, string name, string text, string type
            , string cssClass = "", string placeHolder = "")
        {
            container.AppendLine("<input type='" + type + "' id='" + name + "' name='" + name + "' value='" + text + "'" +
                ((cssClass == "") ? "" : " class='" + cssClass + "'") +
                ((placeHolder == "") ? "" : " placeholder='" + placeHolder + "'") + "/>");
        }

        public static void HtmlInputHidden(StringBuilder container, string name, string text)
        {
            container.AppendLine("<input type='hidden' id='" + name + "' name='" + name + "' value='" + text + "'/>");
        }

        public static void HtmlGrid(StringBuilder container, GPageGrid item)
        {
            container.AppendLine("<script type=\"text/javascript\">");

            container.AppendLine("$(document).ready(function () {");
            container.AppendLine("$('#" + item.Name + "').dataTable();");
            container.AppendLine("});");

            container.AppendLine("var last_target_id = '';");
            container.AppendLine("$(document).click(function(event) {");
            container.AppendLine("  target_class = $(event.target).attr('class');");
            container.AppendLine("  $(\".dt-menu\").hide();");
            container.AppendLine("  if (target_class == 'dt-command') {");
            container.AppendLine("    target_id = '#ul_' + event.target.id;");
            container.AppendLine("    if(last_target_id != target_id){");
            container.AppendLine("      last_target_id = target_id;");
            container.AppendLine("      $(target_id).show();");
            container.AppendLine("    } else {");
            container.AppendLine("      last_target_id = '';");
            container.AppendLine("    }");
            container.AppendLine("  } else {");
            container.AppendLine("    last_target_id = '';");
            container.AppendLine("  }");
            container.AppendLine("});");

            container.AppendLine("</script>");
            container.AppendLine("<table id='" + item.Name + "' class=\"display\" cellspacing=\"0\" width=\"100%\">");
            // Head
            if (item.WithHead)
            {
                container.AppendLine("<thead>");
                container.AppendLine("<tr>");
                foreach (GPageGridColumn gc in item.Columns)
                {
                    // Menu
                    if (gc.TypeId == 2)
                    {
                        container.Append("<th></th>");
                    }
                    else
                    {
                        container.Append("<th>" + gc.HeadText + "</th>");
                    }
                }
                container.AppendLine("</tr>");
                container.AppendLine("</thead>");
            }
            // Foot
            if (item.WithFoot)
            {
                container.AppendLine("<tfoot>");
                container.AppendLine("<tr>");
                foreach (GPageGridColumn gc in item.Columns)
                {
                    // Menu
                    if (gc.TypeId == 2)
                    {
                        container.Append("<th></th>");
                    }
                    else
                    {
                        container.Append("<th>" + gc.FootText + "</th>");
                    }
                }
                container.AppendLine("</tr>");
                container.AppendLine("</tfoot>");
            }
            // Body
            if (item.DataSource != null)
            {
                container.AppendLine("<tbody>");
                int rowIndex = 0;
                foreach (DataRow dr in item.DataSource.Rows)
                {
                    container.AppendLine("<tr>");
                    foreach (GPageGridColumn gc in item.Columns)
                    {
                        // Data Bound
                        if ((gc.TypeId == 1) && item.DataSource.Columns.Contains(gc.DataField))
                        { container.Append("<td>" + dr[gc.DataField].ToString() + "</td>"); }
                        // Menu
                        else if ((gc.TypeId == 2) && (gc.Menu != null))
                        {
                            container.AppendLine("<td><div id=\"dtmenu_" + rowIndex.ToString() + "\" class=\"dt-command\">" + gc.HeadText + "</div>");
                            container.AppendLine("<ul class=\"dt-menu\" id=\"ul_dtmenu_" + rowIndex.ToString() + "\">");
                            foreach (GPageGridColumnMenuItem gmi in gc.Menu)
                            {
                                string imageUrl = "";
                                if (gmi.ImageUrl != "")
                                {
                                    imageUrl = VirtualPathUtility.ToAbsolute(gmi.ImageUrl);
                                }
                                string commandUrl = "";
                                if (gmi.CommandUrl != "")
                                {
                                    commandUrl = gmi.CommandUrl;
                                    foreach (string commandValue in gmi.GetCommandValues())
                                    {
                                        string drValue = "";
                                        if (item.DataSource.Columns.Contains(commandValue))
                                        { drValue = dr[commandValue].ToString(); }

                                        commandUrl = commandUrl.Replace("{" + commandValue + "}", drValue);
                                    }
                                    commandUrl = VirtualPathUtility.ToAbsolute(commandUrl);
                                }
                                container.AppendLine("<li><a href=\"" + commandUrl + "\"><img src=\"" + imageUrl + "\"/><div>" + gmi.Text + "</div></a></li>");
                            }
                            container.AppendLine("</ul>");
                            container.AppendLine("</td>");
                        }
                        else
                        { container.Append("<td></td>"); }
                    }
                    container.AppendLine("</tr>");
                    rowIndex++;
                }
                container.AppendLine("</tbody>");
            }
            container.AppendLine("</table>");
        }

        public static void HtmlFormText(StringBuilder container, string name, string text, string value
            , string cssClass = "", string placeHolder = "")
        {
            container.AppendLine("<div>");
            PGenerate.HtmlLabel(container, name, text);
            container.AppendLine("<div>");
            PGenerate.HtmlInput(container, name, value, "text", cssClass, placeHolder);
            container.AppendLine("</div>");
            container.AppendLine("</div>");
        }
    }
}
