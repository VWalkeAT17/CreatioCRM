define("LocalizationDesigner_FormPage", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"name": "SaveButton",
				"values": {
					"size": "large",
					"iconPosition": "only-text"
				}
			},
			{
				"operation": "remove",
				"name": "SetRecordRightsButton"
			},
			{
				"operation": "merge",
				"name": "MainHeaderBottom",
				"values": {
					"justifyContent": "end",
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch"
				}
			},
			{
				"operation": "remove",
				"name": "CardToolsContainer"
			},
			{
				"operation": "remove",
				"name": "TagSelect"
			},
			{
				"operation": "merge",
				"name": "CardContentWrapper",
				"values": {
					"padding": {
						"left": "small",
						"right": "small",
						"top": "none",
						"bottom": "none"
					},
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"alignItems": "stretch"
				}
			},
			{
				"operation": "merge",
				"name": "SideAreaProfileContainer",
				"values": {
					"columns": [
						"minmax(64px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"visible": true,
					"alignItems": "stretch"
				}
			},
			{
				"operation": "merge",
				"name": "Tabs",
				"values": {
					"styleType": "default",
					"mode": "tab",
					"bodyBackgroundColor": "primary-contrast-500",
					"selectedTabTitleColor": "auto",
					"tabTitleColor": "auto",
					"underlineSelectedTabColor": "auto",
					"headerBackgroundColor": "auto",
					"allowToggleClose": true
				}
			},
			{
				"operation": "merge",
				"name": "GeneralInfoTab",
				"values": {
					"iconPosition": "only-text",
					"visible": true
				}
			},
			{
				"operation": "merge",
				"name": "GeneralInfoTabContainer",
				"values": {
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch"
				}
			},
			{
				"operation": "merge",
				"name": "CardToggleTabPanel",
				"values": {
					"styleType": "default",
					"bodyBackgroundColor": "primary-contrast-500",
					"selectedTabTitleColor": "auto",
					"tabTitleColor": "auto",
					"underlineSelectedTabColor": "auto",
					"headerBackgroundColor": "auto",
					"allowToggleClose": true
				}
			},
			{
				"operation": "remove",
				"name": "FeedTabContainer"
			},
			{
				"operation": "remove",
				"name": "Feed"
			},
			{
				"operation": "remove",
				"name": "FeedTabContainerHeaderContainer"
			},
			{
				"operation": "remove",
				"name": "FeedTabContainerHeaderLabel"
			},
			{
				"operation": "remove",
				"name": "AttachmentsTabContainer"
			},
			{
				"operation": "remove",
				"name": "AttachmentList"
			},
			{
				"operation": "remove",
				"name": "AttachmentsTabContainerHeaderContainer"
			},
			{
				"operation": "remove",
				"name": "AttachmentsTabContainerHeaderLabel"
			},
			{
				"operation": "remove",
				"name": "AttachmentAddButton"
			},
			{
				"operation": "remove",
				"name": "AttachmentRefreshButton"
			},
			{
				"operation": "insert",
				"name": "Input_50kvrlk",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 1,
						"row": 1,
						"rowSpan": 1
					},
					"type": "crt.Input",
					"label": "$Resources.Strings.PageParameters_TextParameter1_pefz1x9",
					"control": "$PageParameters_TextParameter1_pefz1x9",
					"placeholder": "",
					"tooltip": "",
					"readonly": true,
					"multiline": false,
					"labelPosition": "auto",
					"visible": true
				},
				"parentName": "SideAreaProfileContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Input_hcdghr2",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 1,
						"row": 2,
						"rowSpan": 1
					},
					"type": "crt.Input",
					"label": "$Resources.Strings.PageParameters_TextParameter1_g19s21a",
					"control": "$PageParameters_TextParameter1_g19s21a",
					"placeholder": "",
					"tooltip": "",
					"readonly": true,
					"multiline": false,
					"labelPosition": "auto",
					"visible": true
				},
				"parentName": "SideAreaProfileContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "ComboBox_fc2slor",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 1,
						"row": 3,
						"rowSpan": 1
					},
					"type": "crt.ComboBox",
					"label": "$Resources.Strings.PageParameters_LookupParameter1_tr3b0fk",
					"ariaLabel": "",
					"isAddAllowed": true,
					"showValueAsLink": true,
					"labelPosition": "auto",
					"controlActions": [],
					"listActions": [],
					"tooltip": "",
					"control": "$PageParameters_LookupParameter1_tr3b0fk",
					"visible": true,
					"readonly": true,
					"placeholder": "",
					"valueDetails": null,
					"mode": "List"
				},
				"parentName": "SideAreaProfileContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "addRecord_iaculf4",
				"values": {
					"code": "addRecord",
					"type": "crt.ComboboxSearchTextAction",
					"icon": "combobox-add-new",
					"caption": "#ResourceString(addRecord_iaculf4_caption)#",
					"clicked": {
						"request": "crt.CreateRecordFromLookupRequest",
						"params": {}
					}
				},
				"parentName": "ComboBox_fc2slor",
				"propertyName": "listActions",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ComboBox_1w94b5c",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 1,
						"row": 4,
						"rowSpan": 1
					},
					"type": "crt.ComboBox",
					"label": "$Resources.Strings.PageParameters_LookupParameter1_fes3kl1",
					"ariaLabel": "",
					"isAddAllowed": true,
					"showValueAsLink": true,
					"labelPosition": "auto",
					"controlActions": [],
					"listActions": [],
					"tooltip": "",
					"control": "$PageParameters_LookupParameter1_fes3kl1",
					"visible": true,
					"readonly": true,
					"placeholder": "",
					"valueDetails": null,
					"mode": "List"
				},
				"parentName": "SideAreaProfileContainer",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "addRecord_yiex6dt",
				"values": {
					"code": "addRecord",
					"type": "crt.ComboboxSearchTextAction",
					"icon": "combobox-add-new",
					"caption": "#ResourceString(addRecord_yiex6dt_caption)#",
					"clicked": {
						"request": "crt.CreateRecordFromLookupRequest",
						"params": {}
					}
				},
				"parentName": "ComboBox_1w94b5c",
				"propertyName": "listActions",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ComboBox_h7cup6o",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 1,
						"row": 5,
						"rowSpan": 1
					},
					"type": "crt.ComboBox",
					"label": "$Resources.Strings.PageParameters_Culture_g1hstzp",
					"ariaLabel": "",
					"isAddAllowed": true,
					"showValueAsLink": true,
					"labelPosition": "auto",
					"controlActions": [],
					"listActions": [],
					"tooltip": "",
					"control": "$PageParameters_Culture_g1hstzp",
					"mode": "List",
					"visible": false,
					"readonly": true,
					"placeholder": ""
				},
				"parentName": "SideAreaProfileContainer",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "addRecord_g3ckx5b",
				"values": {
					"code": "addRecord",
					"type": "crt.ComboboxSearchTextAction",
					"icon": "combobox-add-new",
					"caption": "#ResourceString(addRecord_g3ckx5b_caption)#",
					"clicked": {
						"request": "crt.CreateRecordFromLookupRequest",
						"params": {}
					}
				},
				"parentName": "ComboBox_h7cup6o",
				"propertyName": "listActions",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_ConfigurationElementFilters",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 2,
						"row": 1,
						"rowSpan": 1
					},
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true
				},
				"parentName": "GeneralInfoTabContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "QuickFilter_ConfigurationElementLcz",
				"values": {
					"type": "crt.QuickFilter",
					"config": {
						"caption": "#ResourceString(QuickFilter_ConfigurationElementLcz_config_caption)#",
						"hint": "",
						"icon": "filter-column-icon",
						"iconPosition": "left-icon",
						"defaultValue": [],
						"entitySchemaName": "SysSchema",
						"recordsFilter": null
					},
					"_filterOptions": {
						"expose": [
							{
								"attribute": "QuickFilter_ConfigurationElementLcz_DataGrid_x3umv3r",
								"converters": [
									{
										"converter": "crt.QuickFilterAttributeConverter",
										"args": [
											{
												"target": {
													"viewAttributeName": "DataGrid_x3umv3r",
													"filterColumn": "SysSchema"
												},
												"quickFilterType": "lookup"
											}
										]
									}
								]
							}
						],
						"from": "QuickFilter_ConfigurationElementLcz_Value"
					},
					"filterType": "lookup"
				},
				"parentName": "FlexContainer_ConfigurationElementFilters",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "SearchFilter_ConfigurationElemLcz",
				"values": {
					"type": "crt.SearchFilter",
					"placeholder": "#ResourceString(SearchFilter_ConfigurationElemLcz_placeholder)#",
					"_filterOptions": {
						"expose": [
							{
								"attribute": "SearchFilter_ConfigurationElemLcz_DataGrid_x3umv3r",
								"converters": [
									{
										"converter": "crt.SearchFilterAttributeConverter",
										"args": [
											"DataGrid_x3umv3r"
										]
									}
								]
							}
						],
						"from": [
							"SearchFilter_ConfigurationElemLcz_SearchValue",
							"SearchFilter_ConfigurationElemLcz_FilteredColumnsGroups"
						]
					}
				},
				"parentName": "FlexContainer_ConfigurationElementFilters",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "DataGrid_ConfigurationElementsLcz",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 2,
						"row": 2,
						"rowSpan": 1
					},
					"type": "crt.DataGrid",
					"features": {
						"rows": {
							"selection": false
						},
						"editable": {
							"enable": false,
							"itemsCreation": false,
							"floatingEditPanel": false
						}
					},
					"items": "$DataGrid_x3umv3r",
					"activeRow": "$DataGrid_x3umv3r_ActiveRow",
					"selectionState": "$DataGrid_x3umv3r_SelectionState",
					"_selectionOptions": {
						"attribute": "DataGrid_x3umv3r_SelectionState"
					},
					"visible": true,
					"fitContent": true,
					"primaryColumnName": "DataGrid_x3umv3rDS_Id",
					"columns": [
						{
							"id": "878cad52-5089-51d6-540c-ab9aab189fb0",
							"code": "DataGrid_x3umv3rDS_SysSchema",
							"caption": "#ResourceString(DataGrid_ConfigurationElementsLcz_caption)#",
							"dataValueType": 10,
							"width": 395
						},
						{
							"id": "5e1752b3-3fc9-3ae2-f714-ed607defb2a1",
							"code": "DataGrid_x3umv3rDS_Key",
							"caption": "#ResourceString(DataGrid_x3umv3rDS_Key)#",
							"dataValueType": 28,
							"width": 397
						},
						{
							"id": "8b6af8be-9450-be30-ec72-2792b9d10b85",
							"code": "DataGrid_x3umv3rDS_Value",
							"caption": "#ResourceString(DataGrid_x3umv3rDS_Value)#",
							"dataValueType": 29,
							"width": 378
						}
					],
					"placeholder": false,
					"bulkActions": []
				},
				"parentName": "GeneralInfoTabContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "DataGrid_x3umv3r_AddTagsBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "Add tag",
					"icon": "tag-icon",
					"clicked": {
						"request": "crt.AddTagsInRecordsRequest",
						"params": {
							"dataSourceName": "DataGrid_x3umv3rDS",
							"filters": "$DataGrid_x3umv3r | crt.ToCollectionFilters : 'DataGrid_x3umv3r' : $DataGrid_x3umv3r_SelectionState | crt.SkipIfSelectionEmpty : $DataGrid_x3umv3r_SelectionState"
						}
					},
					"items": []
				},
				"parentName": "DataGrid_ConfigurationElementsLcz",
				"propertyName": "bulkActions",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "DataGrid_x3umv3r_RemoveTagsBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "Remove tag",
					"icon": "delete-button-icon",
					"clicked": {
						"request": "crt.RemoveTagsInRecordsRequest",
						"params": {
							"dataSourceName": "DataGrid_x3umv3rDS",
							"filters": "$DataGrid_x3umv3r | crt.ToCollectionFilters : 'DataGrid_x3umv3r' : $DataGrid_x3umv3r_SelectionState | crt.SkipIfSelectionEmpty : $DataGrid_x3umv3r_SelectionState"
						}
					}
				},
				"parentName": "DataGrid_x3umv3r_AddTagsBulkAction",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "DataGrid_x3umv3r_ExportToExcelBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "Export to Excel",
					"icon": "export-button-icon",
					"clicked": {
						"request": "crt.ExportDataGridToExcelRequest",
						"params": {
							"viewName": "DataGrid_ConfigurationElementsLcz",
							"filters": "$DataGrid_x3umv3r | crt.ToCollectionFilters : 'DataGrid_x3umv3r' : $DataGrid_x3umv3r_SelectionState | crt.SkipIfSelectionEmpty : $DataGrid_x3umv3r_SelectionState"
						}
					}
				},
				"parentName": "DataGrid_ConfigurationElementsLcz",
				"propertyName": "bulkActions",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "DataGrid_x3umv3r_MergeBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "Merge",
					"icon": "merge-icon",
					"clicked": {
						"request": "crt.MergeRecordsRequest",
						"params": {
							"dataSourceName": "DataGrid_x3umv3rDS",
							"selectionState": "$DataGrid_x3umv3r_SelectionState"
						}
					}
				},
				"parentName": "DataGrid_ConfigurationElementsLcz",
				"propertyName": "bulkActions",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "DataGrid_x3umv3r_DeleteBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "Delete",
					"icon": "delete-button-icon",
					"clicked": {
						"request": "crt.DeleteRecordsRequest",
						"params": {
							"dataSourceName": "DataGrid_x3umv3rDS",
							"filters": "$DataGrid_x3umv3r | crt.ToCollectionFilters : 'DataGrid_x3umv3r' : $DataGrid_x3umv3r_SelectionState | crt.SkipIfSelectionEmpty : $DataGrid_x3umv3r_SelectionState"
						}
					}
				},
				"parentName": "DataGrid_ConfigurationElementsLcz",
				"propertyName": "bulkActions",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "TabContainer_HelpToggleButton",
				"values": {
					"type": "crt.TabContainer",
					"tools": [],
					"items": [],
					"caption": "#ResourceString(TabContainer_HelpToggleButton_caption)#",
					"iconPosition": "left-icon",
					"visible": true,
					"icon": "book-open-icon"
				},
				"parentName": "CardToggleTabPanel",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_HelpTogglePanelHeader",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"alignItems": "center",
					"items": []
				},
				"parentName": "TabContainer_HelpToggleButton",
				"propertyName": "tools",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_455poas",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_455poas_caption)#)#",
					"labelType": "headline-3",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#0D2E4E",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true,
					"headingLevel": "label"
				},
				"parentName": "FlexContainer_HelpTogglePanelHeader",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_HelpTogglePanel",
				"values": {
					"type": "crt.FlexContainer",
					"items": [],
					"direction": "column"
				},
				"parentName": "TabContainer_HelpToggleButton",
				"propertyName": "items",
				"index": 0
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfigDiff: /**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [
					"attributes"
				],
				"values": {
					"DataGrid_x3umv3r": {
						"isCollection": true,
						"modelConfig": {
							"path": "DataGrid_x3umv3rDS",
							"filterAttributes": [
								{
									"name": "QuickFilter_ConfigurationElementLcz_DataGrid_x3umv3r",
									"loadOnChange": true
								},
								{
									"name": "SearchFilter_ConfigurationElemLcz_DataGrid_x3umv3r",
									"loadOnChange": true
								},
								{
									"loadOnChange": true,
									"name": "DataGrid_x3umv3r_PredefinedFilter"
								}
							],
							"sortingConfig": {
								"default": [
									{
										"direction": "desc",
										"columnName": "SysSchema"
									}
								]
							}
						},
						"viewModelConfig": {
							"attributes": {
								"DataGrid_x3umv3rDS_SysSchema": {
									"modelConfig": {
										"path": "DataGrid_x3umv3rDS.SysSchema"
									}
								},
								"DataGrid_x3umv3rDS_Key": {
									"modelConfig": {
										"path": "DataGrid_x3umv3rDS.Key"
									}
								},
								"DataGrid_x3umv3rDS_Value": {
									"modelConfig": {
										"path": "DataGrid_x3umv3rDS.Value"
									}
								},
								"DataGrid_x3umv3rDS_Id": {
									"modelConfig": {
										"path": "DataGrid_x3umv3rDS.Id"
									}
								}
							}
						}
					},
					"DataGrid_x3umv3r_PredefinedFilter": {
						"value": {
							"items": {
								"5196312a-f1ba-4bea-ab91-3af2fe7bde0f": {
									"filterType": 1,
									"comparisonType": 3,
									"isEnabled": true,
									"trimDateTimeParameterToDate": false,
									"leftExpression": {
										"expressionType": 0,
										"columnPath": "ResourceType"
									},
									"isAggregative": false,
									"dataValueType": 4,
									"rightExpression": {
										"expressionType": 2,
										"parameter": {
											"dataValueType": 4,
											"value": 0
										}
									}
								}
							},
							"logicalOperation": 0,
							"isEnabled": true,
							"filterType": 6,
							"rootSchemaName": "SysLocalizableValue"
						}
					},
					"PageParameters_TextParameter1_pefz1x9": {
						"modelConfig": {
							"path": "PageParameters.SchemaCode"
						}
					},
					"PageParameters_TextParameter1_g19s21a": {
						"modelConfig": {
							"path": "PageParameters.SchemaTitle"
						}
					},
					"PageParameters_LookupParameter1_tr3b0fk": {
						"modelConfig": {
							"path": "PageParameters.SchemaPackage"
						}
					},
					"PageParameters_LookupParameter1_tr3b0fk_List": {
						"isCollection": true,
						"modelConfig": {
							"sortingConfig": {
								"default": [
									{
										"columnName": "Name",
										"direction": "asc"
									}
								]
							}
						}
					},
					"PageParameters_LookupParameter1_fes3kl1": {
						"modelConfig": {
							"path": "PageParameters.SchemaLanguage"
						}
					},
					"PageParameters_LookupParameter1_fes3kl1_List": {
						"isCollection": true,
						"modelConfig": {
							"sortingConfig": {
								"default": [
									{
										"columnName": "Name",
										"direction": "asc"
									}
								]
							}
						}
					},
					"PageParameters_Culture_g1hstzp": {
						"modelConfig": {
							"path": "PageParameters.Culture"
						}
					},
					"PageParameters_Culture_g1hstzp_List": {
						"isCollection": true,
						"modelConfig": {
							"sortingConfig": {
								"default": [
									{
										"columnName": "Name",
										"direction": "asc"
									}
								]
							}
						}
					}
				}
			},
			{
				"operation": "merge",
				"path": [
					"attributes",
					"CardState"
				],
				"values": {
					"modelConfig": {}
				}
			}
		]/**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/,
		modelConfigDiff: /**SCHEMA_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [],
				"values": {
					"primaryDataSourceName": "SysSchemaDS",
					"dependencies": {
						"DataGrid_x3umv3rDS": [
							{
								"attributePath": "SysPackage",
								"relationPath": "PageParameters.SchemaPackage"
							},
							{
								"attributePath": "SysCulture",
								"relationPath": "PageParameters.Culture"
							}
						]
					}
				}
			},
			{
				"operation": "merge",
				"path": [
					"dataSources"
				],
				"values": {
					"DataGrid_x3umv3rDS": {
						"type": "crt.EntityDataSource",
						"scope": "viewElement",
						"config": {
							"entitySchemaName": "SysLocalizableValue",
							"attributes": {
								"SysSchema": {
									"path": "SysSchema"
								},
								"Key": {
									"path": "Key"
								},
								"Value": {
									"path": "Value"
								}
							}
						}
					},
					"SysSchemaDS": {
						"type": "crt.EntityDataSource",
						"scope": "page",
						"config": {
							"entitySchemaName": "SysSchema",
							"loadParameters": {
								"options": {
									"pagingConfig": {
										"rowCount": 1,
										"rowsOffset": -1
									},
									"sortingConfig": {
										"columns": []
									}
								}
							},
							"allowCopyingRecords": false
						}
					}
				}
			}
		]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});