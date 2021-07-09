<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="teslimEdilenArizaliCihazlar.aspx.cs" Inherits="TeknikTakip.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div class="col-xs-12 ">
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
                <table class="table table-striped table-bordered table-hover text-center">
                    <thead>

                        <th class=" text-center bg-secondary text-white">Kayıt Açan Id</th>
                        <th class=" text-center bg-secondary text-white">Cihaz Id</th>
                        <th class=" text-center bg-secondary text-white">Ürün Id</th>
                        <th class=" text-center  bg-secondary text-white">Periyodik Bakım </th>
                        <th class=" text-center  bg-secondary text-white">Arıza Nedeni</th>
                     
                        <th class=" text-center  bg-secondary text-white"> Açıklamalar </th>

                        <th class=" text-center  bg-secondary text-white">Verilis Tarihi</th>
                        <th class=" text-center  bg-secondary text-white">Tahmini Teslim Tarihi</th>
                        <th class=" text-center  bg-secondary text-white">Sil</th>

                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text='<%#Eval("kayitEden_id") %> '> </asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("cihaz_id") %> '> </asp:Label>
                        </td>
                         <td>
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("Id") %> '> </asp:Label>
                        </td>
                       
                        <td>
                            <asp:Label ID="Label5" runat="server" Text='<%#Eval("bakim_kontrol") %> '> </asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text='<%#Eval("arıza_nedeni") %> '> </asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label9" runat="server" Text='<%#Eval("aciklamalar") %> '> </asp:Label>
                        </td>                       
                        <td>
                            <asp:Label ID="Label7" runat="server" Text='<%#Eval("verilis_tarihi")%>'> </asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label8" runat="server" Text='<%#Eval("tahmini_teslim_tarihi")%>'> </asp:Label>
                        </td>
                        <td>           
                            <asp:LinkButton ID="sil" runat="server" title="Silmek İçin Tıklayınız" class="fa fa-trash" OnClick="sil_Click" OnClientClick="return confirm('Silmek istiyormusunuz ?')" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>
                        </td>
                    </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>

        </asp:Repeater>
    </div>
</asp:Content>
