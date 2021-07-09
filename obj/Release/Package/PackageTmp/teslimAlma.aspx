<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="teslimAlma.aspx.cs" Inherits="TeknikTakip.WebForm5" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="col-xs-12  ">
        <!--Burada da butona tıklayınca gelecek olan  Bootstrap modal ı ekliyoruz -->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog"
            aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">

                    <div class="form-group">
                        <label>Yapılan İş :</label>
                        <input id="yapilan_is_popup" runat="server" type="text" class="form-control" />
                    </div>
                    <div class="form-group">
                        <label>Değişikliker :</label>
                        <input id="degisiklikler_popup" runat="server" type="text" class="form-control" />
                    </div>
                    
                    <div class="form-group">
                        <label>Alınan Ücret :</label>
                        <input id="ücret_popup" type="text" runat="server" class="form-control" />
                    </div>
                    <asp:Button ID="PopUpTeslim" class="btn btn-info" runat="server" Text="Gönder" OnClick="PopUpTeslim_Click" />

                </div>

            </div>
        </div>
    </div>

    
    <div class="col-xs-12 ">
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
                <table class="table table-striped table-bordered table-hover text-center">
                    <thead>

                        <th class=" text-center bg-secondary text-white">Kayıt Açan</th>
                        <th class=" text-center bg-secondary text-white">Cihaz Bilgileri</th>
                        <th class=" text-center  bg-secondary text-white">Periyodik Bakım </th>
                        <th class=" text-center  bg-secondary text-white">Arıza Nedeni</th>
                        <th class=" text-center  bg-secondary text-white">Açıklamalar</th>
                        <th class=" text-center  bg-secondary text-white">Verilis Tarihi</th>
                        <th class=" text-center  bg-secondary text-white">Tahmini Teslim Tarihi</th>
                        <th class=" text-center  bg-secondary text-white">Teslim Et / Sil</th>

                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tbody>
                    <tr>
                        <td>
                            <%#Eval("kayitEden_id") %> 
                        </td>
                        <td>
                            <%#Eval("firma_adi") %> - <%#Eval("markasi") %> - <%#Eval("modeli") %> - <%#Eval("seriNo") %> 
                        </td>                         
                        
                        <td>
                               <i class="<%#IkonAl(Eval("bakim_kontrol"))%> "></i>
                        </td>
                        <td>
                            <%#Eval("arıza_nedeni") %>
                        </td>

                        <td>
                            <%#Eval("aciklamalar") %> 
                        </td>    
                        <td>
                            <%#Eval("verilis_tarihi")%>
                        </td>
                        <td>
                            <%#Eval("tahmini_teslim_tarihi")%>
                        </td>
                        <td>
                            <asp:LinkButton ID="btn_modal" title="Teslim Etmek İçin Tıklayınız" CssClass=" glyphicon glyphicon-send" runat="server" OnClick="btn_modal_Click1" OnClientClick="return confirm('Teslim Etmek İstiyormusunuz ?')" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>
                            &nbsp;
                           &nbsp;
                            <asp:LinkButton ID="sil" runat="server" title="Silmek İçin Tıklayınız" CssClass="fa fa-trash" OnClick="sil_Click" OnClientClick="return confirm('Silmek istiyormusunuz ?')" CommandArgument='<%#Eval("Id") %>' ></asp:LinkButton>
                            
                        </td>
                    </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>

        </asp:Repeater>
        <asp:HiddenField ID="periyodik_bakım_HiddenField1" runat="server" />
        <asp:HiddenField ID="hiddenfield" runat="server"></asp:HiddenField>
        <asp:HiddenField ID="firma_adi_hiddenfield1" runat="server"></asp:HiddenField>
        <asp:HiddenField ID="cihaz_markasi_hiddenfield2" runat="server"></asp:HiddenField>
        <asp:HiddenField ID="cihaz_modeli_hiddenfield3" runat="server"></asp:HiddenField>
        <asp:HiddenField ID="ariza_nedeni_HiddenField1" runat="server" />
         <asp:HiddenField ID="gösterim_durumu_HiddenField1" runat="server" />
     
    </div>
    <%--<script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/css/bootstrap-datepicker.css" type="text/css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js" type="text/javascript"></script>--%>

    
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css">


    <script type="text/javascript">
        function Gonder() {
            $('#myModal').modal('show');
        }
    </script>

    <script type="text/javascript">
        $(function () {
            $('[id*=verilis_tarihi]').datepicker({
                changeMonth: true,
                changeYear: true,
                altField: "#tarih-db",
                dateFormat: "dd.mm.yy",
                monthNames: ["Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"],
                dayNamesMin: ["Pts", "Sl", "Çrş", "Prş", "Cm", "Cts", "Pzr"],
                language: "tr"
            });
        });
    </script>

</asp:Content>
