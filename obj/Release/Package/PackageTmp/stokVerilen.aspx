<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="stokVerilen.aspx.cs" Inherits="TeknikTakip.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-xs-12">    
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <table class="table table-striped table-bordered table-hover text-center">
                        <thead>
                            
                            
                            <th class=" text-center  bg-secondary text-white">Teslim Eden</th>                            
                            <th class=" text-center  bg-secondary text-white">Ürün Bilgileri</th>
                            <th class="  text-center bg-secondary text-white">Kime verildi</th>
                            <th class=" text-center  bg-secondary text-white">Kullanıldığı Yer</th>
                            <th class=" text-center  bg-secondary text-white">Kaç Adet </th>
                            <th class=" text-center  bg-secondary text-white">Kayit tarihi</th>
                            <th class=" text-center  bg-secondary text-white">Sil</th>

                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr>
                             
                            <td>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("stok_düsen_kul") %> '> </asp:Label>
                            </td>
                            <td>
                                <%#Eval("ürün_adi") %>  / <%#Eval("cinsi") %> / <%#Eval("tür") %> / <%#Eval("renk") %>
                            </td>      
                            
                             <td>
                                <%#Eval("kime_verildi") %> 
                            </td>
                             <td>
                               <%#Eval("kullanildigi_yer") %> 
                            </td>
                             <td>
                              <%#Eval("kac_adet") %> 
                            </td>

                            <td>
                              <%#Eval("kayit_tarihi") %> 
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
</asp:Content>
