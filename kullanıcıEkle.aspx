<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="kullanıcıEkle.aspx.cs" Inherits="TeknikTakip.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="row text-center">
            <h2>Kullanıcı Kayıt</h2>
        </div>
        <div class="col-md-11">
            <label for="firstname" class="col-md-2">Adı :  </label>
            <div class="col-md-9">
                <input type="text" runat="server" class="form-control" id="adi" placeholder="Adını Giriniz.">
            </div>
            
        </div>
        <div class="col-md-11">
            <label for="lastname" class="col-md-2">Soyadı : </label>
            <div class="col-md-9">
                <input type="text" runat="server" class="form-control" id="soyadi" placeholder="Soyadınızı Giriniz.">
            </div>
            
        </div>
        <div class="col-md-11">
            <label for="emailaddress" class="col-md-2">Email : </label>
            <div class="col-md-9">
                <input type="email" runat="server" class="form-control" id="emailaddress" placeholder="Email Adresinizi Giriniz. ">
                <p class="help-block">örnek@gmail.com </p>
            </div>
           
        </div>
        <div class="col-md-11">
            <label for="password" class="col-md-2">Kullanıcı Adı: </label>
            <div class="col-md-9">
                <input class="form-control" runat="server" id="kullaniciAdi" placeholder="Kullanıcı Adınızı Giriniz.">
            </div>
            
        </div>
        <div class="col-md-11">
            <label for="password" class="col-md-2">Şifre: </label>
            <div class="col-md-9">
                <input type="password" runat="server" class="form-control" id="sifre" placeholder="Şifrenizi Giriniz.">
            </div>
            
        </div>

        <div class="row">
            <div class="col-md-10">
                <div class="col-md-10">
                    <asp:Button ID="Button2" class="btn btn-info text-center  container" Height="30px" Width="180" runat="server" Text="Kayıt" OnClick="Button2_Click" />

                </div>
            </div>
        </div>
    </div>

    <div class="col-lg-12 container">
             <div class="w3_hs_bottom bg-light">

        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
                <table class="table table-striped table-bordered table-hover table-responsive text-center">
                    <thead>

                        <th class=" text-center  bg-secondary text-white">ADI</th>
                        <th class=" text-center  bg-secondary text-white">SOYADI </th>
                        <th class=" text-center  bg-secondary text-white">E_POSTA</th>
                        <th class=" text-center  bg-secondary text-white">KULLANICI ADI</th>
                        <th class=" text-center  bg-secondary text-white">ŞİFRE</th>
                        <th class=" text-center  bg-secondary text-white">KAYIT TARİHİ</th>
                        <th class=" text-center  bg-secondary text-white">SİL</th>

                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tbody>
                    <tr>
                        <td class="col-lg-2">
                            <%#Eval("adi") %>
                        </td>
                        <td class="col-lg-1">
                            <%#Eval("soyadi") %>
                        </td>
                        <td class="col-lg-1">
                            <%#Eval("mail") %>
                        </td>
                        <td class="col-lg-2">
                            <%#Eval("kullaniciAdi") %> 
                        </td>
                        <td class="col-lg-2">
                            <%#Eval("sifre")%>
                        </td>
                        <td class="col-lg-2">
                           <%#Eval("kayit_tarihi")%>
                        </td>
                        <td>
                            <asp:LinkButton ID="sil" runat="server" title="Silmek İçin Tıklayınız" CssClass="fa fa-trash text-danger text" OnClick="sil_Click" OnClientClick="return confirm('Silmek istiyormusunuz ?')" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>
                        </td>

                    </tr>
                </tbody>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>

        </asp:Repeater>
                 </div>
    </div>
</asp:Content>
