<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="arizaliGelenCihazlar.aspx.cs" Inherits="TeknikTakip.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class=" col col-lg-12">
        <div class="row  text-center">
            <h2>Yeni Kayıt</h2>
        </div>

    </div>
    <div class="col-md-11">
        <label for="müsteri" class="col-md-2">Müşteri Seç  </label>
        <div class="col-md-9">
            <asp:DropDownList ID="DropDownList1" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" runat="server" Height="50px" Width="250">
            </asp:DropDownList>
        </div>
        <div>
            <label for="müsteri" class="col-md-2">Cihaz Seri NO Seç  </label>
            <div class="col-md-9">
                <asp:DropDownList ID="DropDownList2" CssClass="form-control" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="true" runat="server" Height="50px" Width="250">
                </asp:DropDownList>
            </div>
        </div>
    </div>

    <div class="col-md-11">
        <label class="col-md-2">Markası  </label>
        <div class="col-md-9">
            <asp:TextBox class="form-control bg-danger" ID="markasi" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
        <div>
            <label class="col-md-2">Modeli </label>
            <div class="col-md-9">
                <asp:TextBox class="form-control bg-danger" ID="modeli" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
        </div>
    </div>


    <div class="col-md-11">
        <label class="col-md-2">Seri No  </label>
        <div class="col-md-9">
            <asp:TextBox class="form-control bg-danger" ID="seriNo" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
        <div>
            <label for="password" class="col-md-2">Adaptör No</label>
            <div class="col-md-9">
                <asp:TextBox class="form-control bg-danger" ID="adaptörNo" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
        </div>
    </div>


    <div class="col-md-11">
        <label class="col-md-2">Batarya Seri No  </label>
        <div class="col-md-9">
            <asp:TextBox class="form-control bg-danger" ID="bataryaSeriNo" runat="server" ReadOnly="true"></asp:TextBox>

        </div>
        <div>
            <label for="password" class="col-md-2">Aksesuar Durumu </label>
            <div class="col-md-9">
                <asp:TextBox class="form-control bg-danger" ID="aksesuarDurumu" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-md-11">
        <label class="col-md-2">Arıza  </label>
        <div class="col-md-9">
            <input class="form-control" runat="server" id="ariza_nedeni">
        </div>
        <div>
            <label for="password" class="col-md-2">Açıklamalar  </label>
            <div class="col-md-9">
                <asp:TextBox class="form-control bg-danger" ID="aciklamalar" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-md-11">
        <label for="password" class="col-md-2">Tahmini Teslim Tarihi </label>
        <div class="col-md-9">
            <asp:TextBox class=" container form-control" ID="tahmini_teslim_tarihi" runat="server" AutoCompleteType="Disabled" ReadOnly="true"></asp:TextBox>
         <%--   <asp:RegularExpressionValidator

            ID="RegularExpressionValidator1"

            runat="server"

            ValidationExpression="(a-z|A-Z|0-9)*[^#$%^&amp;*()’]*$"

            ControlToValidate="tahmini_teslim_tarihi"

            ErrorMessage="Lütfen Tarih Seçimini Tekrar Yapınız." />
            
                </div>--%>

    </div>
    <div class="col-md-11">
        <div class="row">
            <div class=" col col-lg-10">
                <div class=" col col-lg-12">
                    <asp:Button ID="kayit" class="btn btn-info text-center" Height="30px" Width="150" runat="server" Text="Kayıt" OnClick="kayit_Click1" />

                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenfield_bakim" runat="server"></asp:HiddenField>


    
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css">

    <script type="text/javascript">
        $(function () {
            $('[id*=tahmini_teslim_tarihi]').datepicker({
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
