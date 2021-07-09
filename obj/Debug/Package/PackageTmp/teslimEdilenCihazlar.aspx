<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="teslimEdilenCihazlar.aspx.cs" Inherits="TeknikTakip.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col" style="text-align: center;">
             <label> Firma Adı Giriniz</label>
            <asp:TextBox CssClass="form-control container text-center" type="text" style="height:20px; width:250px;" ID="searchInput"  AutoCompleteType="Disabled" placeholder="Arama"  runat="server"></asp:TextBox>          
            <asp:LinkButton ID="searchButton" CssClass="fa fa-search" runat="server" OnClick="searchButton_Click"></asp:LinkButton>
        </div>
    </div>

        <div class="col-xs-12">    
            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <table class="table table-striped table-bordered table-hover text-center">
                        <thead>
                            
                            
                            <th class=" text-center  bg-secondary text-white">Teslim Eden</th>     
                            <th class=" text-center  bg-secondary text-white">Firma Adı</th>
                            <th class=" text-center  bg-secondary text-white">Cihaz Bilgileri</th>
                            <th class=" text-center  bg-secondary text-white">Periyodik</th>
                            <th class=" text-center  bg-secondary text-white">Arıza Nedeni</th>
                            <th class=" text-center  bg-secondary text-white">Açıklamalar</th>
                            <th class=" text-center  bg-secondary text-white"> Yapılan İş</th>                                             
                            <th class=" text-center  bg-secondary text-white">Değişiklikler</th>
                            <th class=" text-center  bg-secondary text-white">Ücret</th>
                            <th class=" text-center  bg-secondary text-white">Teslim Tarihi</th>

                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr>
                             
                            <td>
                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("teslim_eden_id") %> '> </asp:Label>
                            </td>
                            <td>
                                <%#Eval("Firma_Adi") %>
                            </td>
                            <td>
                                  <%#Eval("markasi") %> - <%#Eval("modeli") %> - <%#Eval("seriNo") %> 
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
                                <%#Eval("yapilan_is") %> 
                            </td>
                            <td>
                                <%#Eval("degisiklikler") %> 
                            </td>
                            <td>
                                <%#Eval("ücret")%>
                            </td>
                            <td>
                                <%#Eval("kayit_tarihi")%>
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
