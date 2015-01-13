﻿
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive.Disposables;
using System.Windows.Input;
using odm.infra;
namespace odm.ui.activities {
	using global::System.Xml;
	using global::System.Xml.Schema;
	using global::onvif.services;
	
	public partial class AnalyticsSetNameView{
		
		#region Model definition
		
		public class Model{
			
			public Model(
				ConfigDescription[] types
			){
				
				this.types = types;
			}
			private Model(){
			}
			

			public static Model Create(
				ConfigDescription[] types
			){
				var _this = new Model();
				
				_this.types = types;
				return _this;
			}
		
			public ConfigDescription[] types{get;private set;}
		}
			
		#endregion
	
		#region Result definition
		public abstract class Result{
			private Result() { }
			
			public abstract T Handle<T>(
				
				Func<string,ConfigDescription,T> configure,
				Func<T> abort
			);
	
			public bool IsConfigure(){
				return AsConfigure() != null;
			}
			public virtual Configure AsConfigure(){ return null; }
			public class Configure : Result {
				public Configure(string name,ConfigDescription type){
					
					this.name = name;
					
					this.type = type;
					
				}
				public string name{ get; set; }public ConfigDescription type{ get; set; }
				public override Configure AsConfigure(){ return this; }
				
				public override T Handle<T>(
				
					Func<string,ConfigDescription,T> configure,
					Func<T> abort
				){
					return configure(
						name,type
					);
				}
	
			}
			
			public bool IsAbort(){
				return AsAbort() != null;
			}
			public virtual Abort AsAbort(){ return null; }
			public class Abort : Result {
				public Abort(){
					
				}
				
				public override Abort AsAbort(){ return this; }
				
				public override T Handle<T>(
				
					Func<string,ConfigDescription,T> configure,
					Func<T> abort
				){
					return abort(
						
					);
				}
	
			}
			
		}
		#endregion

		public ICommand ConfigureCommand{ get; private set; }
		public ICommand AbortCommand{ get; private set; }
		
		IActivityContext<Result> activityContext = null;
		SingleAssignmentDisposable activityCancellationSubscription = new SingleAssignmentDisposable();
		bool activityCompleted = false;
		//activity has been completed
		event Action OnCompleted = null;
		//activity has been failed
		event Action<Exception> OnError = null;
		//activity has been completed successfully
		event Action<Result> OnSuccess = null;
		//activity has been canceled
		event Action OnCancelled = null;
		
		public AnalyticsSetNameView(Model model, IActivityContext<Result> activityContext) {
			this.activityContext = activityContext;
			if(activityContext!=null){
				activityCancellationSubscription.Disposable = 
					activityContext.RegisterCancellationCallback(() => {
						EnsureAccess(() => {
							CompleteWith(() => {
								if(OnCancelled!=null){
									OnCancelled();
								}
							});
						});
					});
			}
			Init(model);
		}

		
		public void EnsureAccess(Action action){
			if(!CheckAccess()){
				Dispatcher.Invoke(action);
			}else{
				action();
			}
		}

		public void CompleteWith(Action cont){
			if(!activityCompleted){
				activityCompleted = true;
				cont();
				if(OnCompleted!=null){
					OnCompleted();
				}
				activityCancellationSubscription.Dispose();
			}
		}
		public void Success(Result result) {
			CompleteWith(() => {
				if(activityContext!=null){
					activityContext.Success(result);
				}
				if(OnSuccess!=null){
					OnSuccess(result);
				}
			});
		}
		public void Error(Exception error) {
			CompleteWith(() => {
				if(activityContext!=null){
					activityContext.Error(error);
				}
				if(OnError!=null){
					OnError(error);
				}
			});
		}
		public void Cancel() {
			CompleteWith(() => {
				if(activityContext!=null){
					activityContext.Cancel();
				}
				if(OnCancelled!=null){
					OnCancelled();
				}
			});
		}
		public void Success(Func<Result> resultFactory) {
			CompleteWith(() => {
				var result = resultFactory();
				if(activityContext!=null){
					activityContext.Success(result);
				}
				if(OnSuccess!=null){
					OnSuccess(result);
				}
			});
		}
		public void Error(Func<Exception> errorFactory) {
			CompleteWith(() => {
				var error = errorFactory();
				if(activityContext!=null){
					activityContext.Error(error);
				}
				if(OnError!=null){
					OnError(error);
				}
			});
		}
		public void Cancel(Action action) {
			CompleteWith(() => {
				action();
				if(activityContext!=null){
					activityContext.Cancel();
				}
				if(OnCancelled!=null){
					OnCancelled();
				}
			});
		}
		
	}
}
