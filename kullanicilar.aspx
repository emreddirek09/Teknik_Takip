<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="kullanicilar.aspx.cs" Inherits="TeknikTakip.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="col-xs-12">
            <%--     <div class="w3_hs_bottom bg-light">--%>

            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <table class="table table-striped table-bordered table-hover text-center">
                        <thead>
                            
                            <th class="  text-center bg-secondary text-white">Id</th>
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
                            <td>
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("Id") %> '> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("adi") %> '> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("soyadi") %> '> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("mail") %> '> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text='<%#Eval("kullaniciAdi") %> '> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text='<%#Eval("sifre")%>'> </asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text='<%#Eval("kayit_tarihi")%>'> </asp:Label>
                            </td>
                            <td>
                                  <asp:LinkButton ID="sil" runat="server" title="Silmek İçin Tıklayınız" CssClass="fa fa-trash text-danger text" OnClick="sil_Click1" OnClientClick="return confirm('Silmek istiyormusunuz ?')" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>
                            </td>
                            
                        </tr>
                    </tbody>
                </ItemTemplate>

                <FooterTemplate>
                    </table>
                </FooterTemplate>

            </asp:Repeater>
        </div>
</asp:Content>
