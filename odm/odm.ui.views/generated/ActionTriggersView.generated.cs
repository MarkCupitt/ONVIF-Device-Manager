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
	using global::onvif.services;
	
	public partial class ActionTriggersView{
		
		#region Model definition
		
		public interface IModelAccessor{
			ActionTrigger[] triggers{get;set;}
			ActionTrigger selection{get;set;}
			Action1[] actions{get;set;}
			TopicSetType topicSet{get;set;}
			
		}
		public class Model: IModelAccessor, INotifyPropertyChanged{
			
			public Model(){
			}
			

			public static Model Create(
				ActionTrigger[] triggers,
				ActionTrigger selection,
				Action1[] actions,
				TopicSetType topicSet
			){
				var _this = new Model();
				
				_this.origin.triggers = triggers;
				_this.origin.selection = selection;
				_this.origin.actions = actions;
				_this.origin.topicSet = topicSet;
				_this.RevertChanges();
				
				return _this;
			}
		
				private SimpleChangeTrackable<ActionTrigger[]> m_triggers;
				private SimpleChangeTrackable<ActionTrigger> m_selection;
				private SimpleChangeTrackable<Action1[]> m_actions;
				private SimpleChangeTrackable<TopicSetType> m_topicSet;

			private class OriginAccessor: IModelAccessor {
				private Model m_model;
				public OriginAccessor(Model model) {
					m_model = model;
				}
				ActionTrigger[] IModelAccessor.triggers {
					get {return m_model.m_triggers.origin;}
					set {m_model.m_triggers.origin = value;}
				}
				ActionTrigger IModelAccessor.selection {
					get {return m_model.m_selection.origin;}
					set {m_model.m_selection.origin = value;}
				}
				Action1[] IModelAccessor.actions {
					get {return m_model.m_actions.origin;}
					set {m_model.m_actions.origin = value;}
				}
				TopicSetType IModelAccessor.topicSet {
					get {return m_model.m_topicSet.origin;}
					set {m_model.m_topicSet.origin = value;}
				}
				
			}
			public event PropertyChangedEventHandler PropertyChanged;
			private void NotifyPropertyChanged(string propertyName){
				var prop_changed = this.PropertyChanged;
				if (prop_changed != null) {
					prop_changed(this, new PropertyChangedEventArgs(propertyName));
				}
			}
			
			public ActionTrigger[] triggers  {
				get {return m_triggers.current;}
				set {
					if(m_triggers.current != value) {
						m_triggers.current = value;
						NotifyPropertyChanged("triggers");
					}
				}
			}
			
			public ActionTrigger selection  {
				get {return m_selection.current;}
				set {
					if(m_selection.current != value) {
						m_selection.current = value;
						NotifyPropertyChanged("selection");
					}
				}
			}
			
			public Action1[] actions  {
				get {return m_actions.current;}
				set {
					if(m_actions.current != value) {
						m_actions.current = value;
						NotifyPropertyChanged("actions");
					}
				}
			}
			
			public TopicSetType topicSet  {
				get {return m_topicSet.current;}
				set {
					if(m_topicSet.current != value) {
						m_topicSet.current = value;
						NotifyPropertyChanged("topicSet");
					}
				}
			}
			
			public void AcceptChanges() {
				m_triggers.AcceptChanges();
				m_selection.AcceptChanges();
				m_actions.AcceptChanges();
				m_topicSet.AcceptChanges();
				
			}

			public void RevertChanges() {
				this.current.triggers= this.origin.triggers;
				this.current.selection= this.origin.selection;
				this.current.actions= this.origin.actions;
				this.current.topicSet= this.origin.topicSet;
				
			}

			public bool isModified {
				get {
					if(m_triggers.isModified)return true;
					if(m_selection.isModified)return true;
					if(m_actions.isModified)return true;
					if(m_topicSet.isModified)return true;
					
					return false;
				}
			}

			public IModelAccessor current {
				get {return this;}
				
			}

			public IModelAccessor origin {
				get {return new OriginAccessor(this);}
				
			}
		}
			
		#endregion
	
		#region Result definition
		public abstract class Result{
			private Result() { }
			
			public abstract T Handle<T>(
				
				Func<Model,T> create,
				Func<Model,T> delete,
				Func<Model,T> modify,
				Func<T> close
			);
	
			public bool IsCreate(){
				return AsCreate() != null;
			}
			public virtual Create AsCreate(){ return null; }
			public class Create : Result {
				public Create(Model model){
					
					this.model = model;
					
				}
				public Model model{ get; set; }
				public override Create AsCreate(){ return this; }
				
				public override T Handle<T>(
				
					Func<Model,T> create,
					Func<Model,T> delete,
					Func<Model,T> modify,
					Func<T> close
				){
					return create(
						model
					);
				}
	
			}
			
			public bool IsDelete(){
				return AsDelete() != null;
			}
			public virtual Delete AsDelete(){ return null; }
			public class Delete : Result {
				public Delete(Model model){
					
					this.model = model;
					
				}
				public Model model{ get; set; }
				public override Delete AsDelete(){ return this; }
				
				public override T Handle<T>(
				
					Func<Model,T> create,
					Func<Model,T> delete,
					Func<Model,T> modify,
					Func<T> close
				){
					return delete(
						model
					);
				}
	
			}
			
			public bool IsModify(){
				return AsModify() != null;
			}
			public virtual Modify AsModify(){ return null; }
			public class Modify : Result {
				public Modify(Model model){
					
					this.model = model;
					
				}
				public Model model{ get; set; }
				public override Modify AsModify(){ return this; }
				
				public override T Handle<T>(
				
					Func<Model,T> create,
					Func<Model,T> delete,
					Func<Model,T> modify,
					Func<T> close
				){
					return modify(
						model
					);
				}
	
			}
			
			public bool IsClose(){
				return AsClose() != null;
			}
			public virtual Close AsClose(){ return null; }
			public class Close : Result {
				public Close(){
					
				}
				
				public override Close AsClose(){ return this; }
				
				public override T Handle<T>(
				
					Func<Model,T> create,
					Func<Model,T> delete,
					Func<Model,T> modify,
					Func<T> close
				){
					return close(
						
					);
				}
	
			}
			
		}
		#endregion

		public ICommand CreateCommand{ get; private set; }
		public ICommand DeleteCommand{ get; private set; }
		public ICommand ModifyCommand{ get; private set; }
		public ICommand CloseCommand{ get; private set; }
		
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
		
		public ActionTriggersView(Model model, IActivityContext<Result> activityContext) {
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
