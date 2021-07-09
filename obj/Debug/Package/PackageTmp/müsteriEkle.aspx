<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="müsteriEkle.aspx.cs" Inherits="TeknikTakip.WebForm3" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <script type="text/javascript">
        function güncelle_popup() {
            $('#güncelle_modal').modal('show');
        }
    </script>

    <div class="col-xs-12  ">
        <!--Burada da butona tıklayınca gelecek olan  Bootstrap modal ı ekliyoruz -->
        <div class="modal fade" id="güncelle_modal" tabindex="-1" role="dialog"
            aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">

                    <div class="form-group">
                        <label for="firstname" class="col-md-12">Firma Adı  </label>
                        <input type="text" class="form-control" id="firma_Adi_popup" runat="server" placeholder="Firma Adı.">
                    </div>


                    <div class="form-group">
                        <label for="lastname" class="col-md-12">Yetkili Kişi  </label>
                        <input type="text" class="form-control" id="yetkili_kisi_popup" runat="server" placeholder="Yetkili Kişi.">
                    </div>


                    <div class="form-group">
                        <label for="emailaddress" class="col-md-12">Email  </label>
                        <input type="email" class="form-control" runat="server" id="email1_popup" placeholder="örnek@gmail.com ">
                    </div>



                    <div class="form-group">
                        <label for="password" class="col-md-12">Telefon  </label>
                        <input type="text" id="telefon_popup" maxlength="10" class="form-control" runat="server">
                    </div>


                    <div class="form-group">
                        <label class="col-md-3">Periyodik Bakım : </label>
                        <asp:CheckBox ID="periyodik_Bakim_CheckBox1_popup" runat="server" />
                    </div>


                    <div class="form-group">
                        <label class="col-md-12">Başlangıç Tarihi </label>
                        <asp:TextBox class="form-control" ID="baslangic_tarihi_popup" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>


                    <div class="form-group">
                        <label class="col-md-12">Bitiş Tarihi   </label>
                        <asp:TextBox class="form-control" ID="bitis_tarihi_popup" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>


                    <asp:Button ID="PopUpGüncelle" class="btn btn-info" runat="server" Text="Gönder" OnClick="PopUpGüncelle_Click1" />

                </div>

            </div>
        </div>
    </div>
    <div class="row text-center">
        <h2>Müşteri Ekle</h2>
    </div>

   <div class="col-md-11">
        <label for="firstname" class="col-md-2">Firma Adı  </label>
        <div class="col-md-9">
            <input type="text" class="form-control" id="Firma_Adi" runat="server" placeholder="Firma Adı.">
        </div>
    </div>
    <div class="col-md-11">
        <label for="lastname" class="col-md-2">Yetkili Kişi  </label>
        <div class="col-md-9">
            <input type="text" class="form-control" id="Yetkili_Kisi" runat="server" placeholder="Yetkili Kişi.">
        </div>
    </div>


    <div class="col-md-11">
        <label for="emailaddress" class="col-md-2">Email  </label>
        <div class="col-md-9">
            <input type="email" class="form-control" runat="server" id="emailaddress" placeholder="örnek@gmail.com ">
        </div>
    </div>


    <div class="col-md-11">
        <label for="password" class="col-md-2">Telefon  </label>
        <div class="col-md-9">
            <input type="text" id="iletisim" maxlength="10" class="form-control" runat="server">
        </div>
    </div>


   <div class="col-md-11">
        <label class="col-md-2">Periyodik Bakım  </label>
        <div class="col-md-9">
            <asp:CheckBox ID="periyodik_bakim_CheckBox1" runat="server" />
        </div>
    </div>
    
<div class=" text-left">
    <div class="col-md-11">
        <label class="col-md-2">Başlangıç Tarihi</label>
        <div class="col-md-9">
            <asp:TextBox class="form-control" ID="baslangic_tarihi" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
        </div>
    </div>

    
        <div class="col-md-11">
            <label class="col-md-2">Bitiş Tarihi</label>
            <div class="col-md-9">
                <asp:TextBox class="form-control" ID="bitis_tarihi" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
            </div>
        </div>

        <div>
            <div class="col-md-6">
                <asp:Button ID="Button1" class="btn btn-info text-center" Height="30px" Width="150" runat="server" OnClick="Button1_Click" Text="Ekle" />
            </div>
        </div>
    </div>

    <div class="col-xs-12 ">
        <asp:Label ID="id" runat="server"></asp:Label>
        <asp:HiddenField ID="sec_id_HiddenField1" runat="server" />
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
                <table class="table table-striped table-bordered table-hover text-center">
                    <thead>
                        <th class=" text-center  bg-secondary text-white">Firma Adı</th>
                        <th class=" text-center  bg-secondary text-white">Yekili Kişi </th>
                        <th class=" text-center  bg-secondary text-white">E-Posta</th>
                        <th class=" text-center  bg-secondary text-white">İletişim</th>
                        <th class=" text-center  bg-secondary text-white">Periyodik Bakım</th>
                        <th class=" text-center  bg-secondary text-white">Bakım Başlangıç Tarihi</th>
                        <th class=" text-center  bg-secondary text-white">Bakım Bitiş Tarihi</th>
                        <th class=" text-center  bg-secondary text-white">Kayıt Tarihi</th>
                        <th class=" text-center  bg-secondary text-white">Güncelle</th>
                        <th class=" text-center  bg-secondary text-white">Sil</th>

                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tbody>
                    <tr>
                        <td>
                            <%#Eval("Firma_Adi") %> 
                        </td>
                        <td>
                            <%#Eval("Yetkili_Kisi") %>
                        </td>
                        <td>
                            <%#Eval("mail") %> 
                        </td>
                        <td>
                            <%#Eval("iletisim") %>
                        <td>
                            <i class="<%#IkonAl(Eval("periyodik_bakim"))%> "></i>

                        </td>
                        <td>
                            <%#Eval("bakim_baslangic") %> 
                        </td>
                        <td>
                            <%#Eval("bakim_bitis") %> 
                        </td>
                        <td>
                            <%#Eval("kayit_tarihi")%>
                        </td>
                        <td>
                            <asp:LinkButton ID="Güncelle" type="submit" runat="server" CssClass=" fa fa-refresh" OnClick="Güncelle_Click1" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>

                        </td>
                        <td>
                            <asp:LinkButton ID="sil" runat="server" title="Silmek İçin Tıklayınız" CssClass="fa fa-trash" OnClick="sil_Click" OnClientClick="return confirm('Silmek istiyormusunuz ?')" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>
                        </td>

                    </tr>
                </tbody>
            </ItemTemplate>

            <FooterTemplate>
                </table>
            </FooterTemplate>

        </asp:Repeater>
    </div>

    <asp:HiddenField ID="hiddenfield" runat="server"></asp:HiddenField>

    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css">

    <script type="text/javascript">
        $(function () {

            $('[id*=baslangic_tarihi]').datepicker({
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
    <script type="text/javascript">
        $(function () {
            $('[id*=bitis_tarihi]').datepicker(
                {
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

    <script type="text/javascript">
        $(function () {

            $('[id*=baslangic_tarihi_popup]').datepicker({
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
    <script type="text/javascript">
        $(function () {
            $('[id*=bitis_tarihi_popup]').datepicker(
                {
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
